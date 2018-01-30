namespace Cookbook.BLL.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;

    using Cookbook.BLL.DataTransferObjects;
    using Cookbook.BLL.Services.Interfaces;
    using Cookbook.DAL.Entities;
    using Cookbook.DAL.Enums;
    using Cookbook.DAL.Repositories.Interfaces;

    /// <summary>
    ///     The measuring units service.
    /// </summary>
    public class MeasuringUnitsService: IMeasuringUnitsService
    {
        /// <summary>
        ///     The mapper.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        ///     The measuring units repository.
        /// </summary>
        private readonly IRepository<MeasuringUnit> measuringUnitsRepository;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MeasuringUnitsService"/> class.
        /// </summary>
        /// <param name="mapper">
        ///     The mapper.
        /// </param>
        /// <param name="measuringUnitsRepository">
        ///     The measuring units repository.
        /// </param>
        public MeasuringUnitsService(IMapper mapper, IRepository<MeasuringUnit> measuringUnitsRepository)
        {
            this.mapper = mapper;
            this.measuringUnitsRepository = measuringUnitsRepository;
        }

        /// <summary>
        ///     Returns measuring units for ingredients..
        /// </summary>
        /// <returns>
        ///     The <see cref="Task{ICollection{MeasuringUnitDTO}}"/>.
        /// </returns>
        public async Task<ICollection<MeasuringUnitDTO>> GetNutritionMeasuringUnits()
        {
            return await this.GetMeasuringUnits(EMeasuringUnitType.Nutrient);
        }

        /// <summary>
        ///     Returns measuring units for nutrition.
        /// </summary>
        /// <returns>
        ///     The <see cref="Task{ICollection{MeasuringUnitDTO}}"/>.
        /// </returns>
        public async Task<ICollection<MeasuringUnitDTO>> GetIngredientsMeasuringUnits()
        {
            return await this.GetMeasuringUnits(EMeasuringUnitType.Ingredients);
        }

        /// <summary>
        ///     Returns measuring units by type.
        /// </summary>
        /// <param name="measuringUnitType">
        ///     Measuring unit type.
        /// </param>
        /// <returns>
        ///     See <see cref="Task{ICollection{MeasuringUnitDTO}}"/>
        /// </returns>
        private async Task<ICollection<MeasuringUnitDTO>> GetMeasuringUnits(EMeasuringUnitType measuringUnitType)
        {
            return await Task.Run(
                () =>
                    {
                        var measuringUnitTypeName = measuringUnitType.ToString();
                        var measuringUnits = this.measuringUnitsRepository.Get(
                            units => units.Where(unit => unit.MeasuringUnitType.Name == measuringUnitTypeName)
                                .ToList());
                        return measuringUnits
                                   .Select(this.mapper.Map<MeasuringUnitDTO>)
                                   .ToList();
                    });
        }
    }
}