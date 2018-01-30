namespace Cookbook.BLL.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Cookbook.BLL.DataTransferObjects;

    /// <summary>
    ///     The MeasuringUnitsService interface.
    /// </summary>
    public interface IMeasuringUnitsService
    {
        /// <summary>
        ///     Returns measuring units for ingredients..
        /// </summary>
        /// <returns>
        ///     The <see cref="Task{ICollection{MeasuringUnitDTO}}"/>.
        /// </returns>
        Task<ICollection<MeasuringUnitDTO>> GetIngredientsMeasuringUnits();

        /// <summary>
        ///     Returns measuring units for nutrition.
        /// </summary>
        /// <returns>
        ///     The <see cref="Task{ICollection{MeasuringUnitDTO}}"/>.
        /// </returns>
        Task<ICollection<MeasuringUnitDTO>> GetNutritionMeasuringUnits();
    }
}