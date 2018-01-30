namespace Cookbook.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using System.Web.Http.Description;

    using Cookbook.BLL.DataTransferObjects;
    using Cookbook.BLL.DataTransferObjects.CreateRecipeDTOs;
    using Cookbook.BLL.Services.Interfaces;

    /// <summary>
    ///     The controller for working with recipes.
    /// </summary>
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("api/recipe")]
    public class RecipeController : ApiController
    {
        /// <summary>
        ///     The recipes service.
        /// </summary>
        private readonly IRecipesService recipesService;

        /// <inheritdoc />
        public RecipeController(IRecipesService recipesService)
        {
            this.recipesService = recipesService;
        }

        /// <summary>
        ///     Returns collection of recipes based on take and skip options.
        /// </summary>
        /// <param name="take">
        ///     The take.
        /// </param>
        /// <param name="skip">
        ///     The skip.
        /// </param>
        /// <returns>
        /// The <see>
        ///         <cref>Task{ICollection{RecipeShortInfoDTO}}</cref>
        ///     </see>.
        /// </returns>
        [HttpGet]
        [ResponseType(typeof(ICollection<RecipeShortInfoDTO>))]
        public async Task<ICollection<RecipeShortInfoDTO>> GetRecipes(int take = 12, int skip = 0)
        {
            return await this.recipesService.GetRecipes(take, skip);
        }

        /// <summary>
        ///     Returns recipe full info.
        /// </summary>
        /// <param name="id">
        ///     The recipe id.
        /// </param>
        /// <returns>
        ///     The <see cref="RecipeInfoDTO"/>.
        /// </returns>
        [HttpGet]
        [ResponseType(typeof(RecipeInfoDTO))]
        public async Task<RecipeInfoDTO> GetRecipe(int id)
        {
            return await this.recipesService.GetRecipeAsync(id);
        }

        /// <summary>
        ///     Creates new recipe.
        /// </summary>
        /// <param name="recipe">
        ///     The recipe.
        /// </param>
        /// <returns>
        ///     The <see cref="Task{RecipeInfoDTO}"/>.
        /// </returns>
        [HttpPost]
        [ResponseType(typeof(RecipeInfoDTO))]
        public async Task<RecipeInfoDTO> CreateRecipe(CreateRecipeDTO recipe)
        {
            return await this.recipesService.CreateRecipe(recipe);
        }

        /// <summary>
        ///     Creates new recipe.
        /// </summary>
        /// <param name="recipe">
        ///     The recipe.
        /// </param>
        /// <returns>
        ///     The <see cref="Task{RecipeInfoDTO}"/>.
        /// </returns>
        [HttpPost]
        [ResponseType(typeof(RecipeInfoDTO))]
        [Route("empty")]
        public async Task<RecipeInfoDTO> CreateEmptyRecipe()
        {
            return await this.recipesService.CreateRecipe();
        }

        /// <summary>
        ///     Updates recipe.
        /// </summary>
        /// <param name="recipe">
        ///     The recipe.
        /// </param>
        /// <returns>
        ///     The <see cref="Task{RecipeInfoDTO}"/>.
        /// </returns>
        [HttpPut]
        [ResponseType(typeof(RecipeInfoDTO))]
        public async Task<RecipeInfoDTO> UpdateRecipe(RecipeInfoDTO recipe)
        {
            return await this.recipesService.UpdateRecipe(recipe);
        }

        /// <summary>
        ///     The get recipe history.
        /// </summary>
        /// <param name="id">
        ///     The recipe id.
        /// </param>
        /// <param name="take">
        ///     The take.
        /// </param>
        /// <param name="skip">
        ///     The skip.
        /// </param>
        /// <returns>
        ///     The <see cref="ICollection{RecipeShortInfoDTO}"/>.
        /// </returns>
        [HttpGet]
        [ResponseType(typeof(ICollection<RecipeShortInfoDTO>))]
        [Route("{id}/history")]
        public async Task<ICollection<RecipeShortInfoDTO>> GetRecipeHistory(int id, int take = 12, int skip = 0)
        {
            return await this.recipesService.GetRecipeHistory(id, take, skip);
        }

        [HttpDelete]
        [ResponseType(typeof(bool))]
        [Route("{id:int}")]
        public async Task<bool> DeleteRecipe(int id)
        {
            return await this.recipesService.DeleteRecipe(id);
        }
    }
}
