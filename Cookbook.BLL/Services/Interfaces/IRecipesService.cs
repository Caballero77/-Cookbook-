namespace Cookbook.BLL.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Cookbook.BLL.DataTransferObjects;
    using Cookbook.BLL.DataTransferObjects.CreateRecipeDTOs;

    /// <summary>
    ///     The RecipesService interface.
    /// </summary>
    public interface IRecipesService
    {
        /// <summary>
        ///     Creates new recipe.
        /// </summary>
        /// <param name="recipe">
        ///     The recipe.
        /// </param>
        /// <returns>
        ///     The <see cref="Task{RecipeInfoDTO}"/>.
        /// </returns>
        Task<RecipeInfoDTO> CreateRecipe(CreateRecipeDTO recipe = null);

        /// <summary>
        ///     Returns recipe by id.
        /// </summary>
        /// <param name="id">
        ///     The recipe id.
        /// </param>
        ///     <returns>
        /// The <see cref="Task{RecipeInfoDTO}"/>.
        /// </returns>
        Task<RecipeInfoDTO> GetRecipeAsync(int id);

        /// <summary>
        ///     Returns recipe history with padding.
        /// </summary>
        /// <param name="recipeId">
        ///     The recipe id.
        /// </param>
        /// <param name="take">
        ///     Take. Default 25.
        /// </param>
        /// <param name="skip">
        ///     Skip. Default 0.
        /// </param>
        /// <returns>
        ///     The <see cref="Task{ICollection{RecipeShortInfoDTO}}"/>.
        /// </returns>
        Task<ICollection<RecipeShortInfoDTO>> GetRecipeHistory(int recipeId, int take = 25, int skip = 0);

        /// <summary>
        ///     Returns all recipes with padding.
        /// </summary>
        /// <param name="take">
        ///     Take. Default 25.
        /// </param>
        /// <param name="skip">
        ///     Skip. Default 0.
        /// </param>
        /// <returns>
        ///     The <see cref="Task{ICollection{RecipeShortInfoDTO}}"/>.
        /// </returns>
        Task<ICollection<RecipeShortInfoDTO>> GetRecipes(int take = 25, int skip = 0);

        /// <summary>
        ///     Updates recipe.
        /// </summary>
        /// <param name="recipe">
        ///     The recipe.
        /// </param>
        /// <returns>
        ///     The <see cref="Task{RecipeInfoDTO}"/>.
        /// </returns>
        Task<RecipeInfoDTO> UpdateRecipe(RecipeInfoDTO recipe);

        /// <summary>
        ///     Deletes recipe by id.
        /// </summary>
        /// <param name="id">Recipe id.</param>
        /// <returns>Is deletion was successfull.</returns>
        Task<bool> DeleteRecipe(int id);
    }
}