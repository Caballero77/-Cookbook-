namespace Cookbook.BLL.Services.Implementations
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;

    using Cookbook.BLL.DataTransferObjects;
    using Cookbook.BLL.Services.Interfaces;
    using Cookbook.DAL.Entities;
    using Cookbook.DAL.Repositories.Interfaces;

    /// <summary>
    ///     The nutrition service.
    /// </summary>
    public class NutritionService: INutritionService
    {
        /// <summary>
        ///     The nutrition repository.
        /// </summary>
        private readonly IRepository<NutritionValue> nutritionRepository;

        /// <summary>
        ///     The mapper.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        ///     Initializes a new instance of the <see cref="NutritionService"/> class.
        /// </summary>
        /// <param name="mapper">
        ///     The mapper.
        /// </param>
        /// <param name="nutritionRepository">
        ///     The nutrition repository.
        /// </param>
        public NutritionService(IMapper mapper, IRepository<NutritionValue> nutritionRepository)
        {
            this.mapper = mapper;
            this.nutritionRepository = nutritionRepository;
        }

        /// <summary>
        ///     Returns all nutrition.
        /// </summary>
        /// <returns>
        ///     The <see cref="Task{ICollection{NutritionValueDTO}}"/>.
        /// </returns>
        public async Task<ICollection<NutritionValueDTO>> GetAllNutrition()
        {
            return await Task.FromResult(this.nutritionRepository.Get()
                .Select(nutrition => this.mapper.Map<NutritionValueDTO>(nutrition))
                .ToList());
        }


    }
}