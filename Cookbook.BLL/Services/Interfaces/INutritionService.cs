namespace Cookbook.BLL.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Cookbook.BLL.DataTransferObjects;

    /// <summary>
    ///     The NutritionService interface.
    /// </summary>
    public interface INutritionService
    {
        /// <summary>
        ///     Returns all nutrition.
        /// </summary>
        /// <returns>
        ///     The <see cref="Task{ICollection{NutritionValueDTO}}"/>.
        /// </returns>
        Task<ICollection<NutritionValueDTO>> GetAllNutrition();
    }
}