namespace Cookbook.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using System.Web.Http.Description;

    using Cookbook.BLL.DataTransferObjects;
    using Cookbook.BLL.Services.Interfaces;

    /// <summary>
    ///     The nutrition controller.
    /// </summary>
    [EnableCors("http://localhost:4200", "*", "*")]
    public class NutritionController : ApiController
    {
        /// <summary>
        ///     The nutrition service.
        /// </summary>
        private readonly INutritionService nutritionService;

        /// <summary>
        ///     Initializes a new instance of the <see cref="NutritionController"/> class.
        /// </summary>
        /// <param name="nutritionService">
        ///     The nutrition service.
        /// </param>
        public NutritionController(INutritionService nutritionService)
        {
            this.nutritionService = nutritionService;
        }

        /// <summary>
        ///     The get all nutrition.
        /// </summary>
        /// <returns>
        ///     The <see cref="Task{ICollection{NutritionValueDTO}}"/>.
        /// </returns>
        [HttpGet]
        [ResponseType(typeof(ICollection<NutritionValueDTO>))]
        public async Task<ICollection<NutritionValueDTO>> GetAllNutrition()
        {
            return await this.nutritionService.GetAllNutrition();
        }
    }
}
