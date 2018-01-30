namespace Cookbook.BLL.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Reactive.Linq;

    using AutoMapper;

    using Cookbook.BLL.DataTransferObjects;
    using Cookbook.BLL.DataTransferObjects.CreateRecipeDTOs;
    using Cookbook.BLL.Services.Interfaces;
    using Cookbook.DAL;
    using Cookbook.DAL.Entities;
    using Cookbook.DAL.Repositories.Implementations;
    using Cookbook.DAL.Repositories.Interfaces;

    public class RecipesService: IRecipesService
    {
        private readonly IRepository<Recipe> recipes;

        private readonly IRepository<RecipeInfo> recipeInfo;

        private readonly IMapper mapper;

        public RecipesService(IRepository<Recipe> recipes, IMapper mapper, IRepository<RecipeInfo> recipeInfo)
        {
            this.recipes = recipes;
            this.mapper = mapper;
            this.recipeInfo = recipeInfo;
        }

        public async Task<ICollection<RecipeShortInfoDTO>> GetRecipes(int take = 25, int skip = 0)
        {
            var recipesAsync = this.recipes.Get(
                 dbSet => dbSet.OrderBy(recipe => recipe.RecipeInfo.CreationDate)
                                   .Where(
                                       recipe => !dbSet.Select(r => r.PreviousVersion.Id)
                                                     .Contains(recipe.Id))
                                   .Skip(skip)
                                   .Take(take)
                                   .ToList());
            return recipesAsync
                .Select(recipe => this.mapper.Map<RecipeShortInfoDTO>(recipe))
                .ToList();
        }

        public Task<ICollection<RecipeShortInfoDTO>> GetRecipeHistory(int recipeId, int take = 25, int skip = 0)
        {
            return Task<ICollection<RecipeShortInfoDTO>>.Factory.StartNew(
                () =>
                    {
                        var recipe = this.recipes.Find(recipeId);
                        var position = 1;

                        if (recipe == null)
                        {
                            throw new ArgumentException($"Can`t find recipe with id: {recipeId}");
                        }

                        var result = new List<RecipeShortInfoDTO>();

                        while (recipe != null)
                        {
                            if (position < skip)
                            {
                                position++;
                                continue;
                            }

                            if (position - skip > take)
                            {
                                break;
                            }

                            result.Add(this.mapper.Map<RecipeShortInfoDTO>(recipe));
                            recipe = recipe.PreviousVersion;
                            position++;
                        }
                        return result;
                    });
        }

        public async Task<RecipeInfoDTO> GetRecipeAsync(int id)
        {
            var recipeAsync = await this.recipes.FindAsync(id);

            var recipeInfo = this.mapper.Map<RecipeInfoDTO>(recipeAsync);

            return recipeInfo;
        }

        public async Task<RecipeInfoDTO> CreateRecipe(CreateRecipeDTO recipe = null)
        {
            if (recipe == null)
            {
                recipe = this.GetEmptyRecipe();
            }

            var newRecipe = this.mapper.Map<Recipe>(recipe);
            newRecipe.RecipeInfo.CreationDate = DateTime.UtcNow;

            this.recipes.Add(newRecipe);

            await this.recipes.SaveChangesAsync();

            return this.mapper.Map<RecipeInfoDTO>(newRecipe);
        }

        public async Task<RecipeInfoDTO> UpdateRecipe(RecipeInfoDTO recipe)
        {
            var lastVersion = this.recipes.Find(recipe.Id);
            lastVersion.IsHistoryItem = true;

            var newVersion = this.mapper.Map<Recipe>(recipe);
            newVersion.PreviousVersion = lastVersion;
            newVersion.UpdateTime = DateTime.UtcNow;
            newVersion.IsHistoryItem = false;

            this.recipes.Add(newVersion);

            await this.recipes.SaveChangesAsync();

            return this.mapper.Map<RecipeInfoDTO>(newVersion);
        }

        private CreateRecipeDTO GetEmptyRecipe()
        {
            return new CreateRecipeDTO {
                CookTime = 0,
                CreationDate = DateTime.UtcNow,
                Description = "New recipe",
                Name = "New recipe",
                PreparationTime = 0,
                Tip = string.Empty,
                UpdateTime = DateTime.UtcNow,
                ServingsCount = 0
            };
        }

        public async Task<bool> DeleteRecipe(int id)
        {
            var recipe = await this.recipes.FindAsync(id);
            var removed = new List<Recipe>();

            while (recipe != null)
            {
                removed.Add(recipe);
                recipe = recipe.PreviousVersion;
            }

            this.recipeInfo.RemoveRange(removed.Select(r => r.RecipeInfo).ToList());
            this.recipes.RemoveRange(removed);
            return await this.recipes.SaveChangesAsync() > 0;
        }
    }
}