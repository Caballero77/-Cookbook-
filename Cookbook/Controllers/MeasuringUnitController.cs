using System.Collections.Generic;
using System.Web.Http;

namespace Cookbook.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http.Cors;
    using System.Web.Http.Description;

    using Cookbook.BLL.DataTransferObjects;
    using Cookbook.BLL.Services.Interfaces;

    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("api/measuring-units")]
    public class MeasuringUnitController : ApiController
    {
        private readonly IMeasuringUnitsService measuringUnitsService;

        public MeasuringUnitController(IMeasuringUnitsService measuringUnitsService)
        {
            this.measuringUnitsService = measuringUnitsService;
        }

        [HttpGet]
        [ResponseType(typeof(ICollection<MeasuringUnitDTO>))]
        [Route("nutrition")]
        public async Task<ICollection<MeasuringUnitDTO>> GetNutritionMeasuringUnits()
        {
            return await this.measuringUnitsService.GetNutritionMeasuringUnits();
        }

        [HttpGet]
        [ResponseType(typeof(ICollection<MeasuringUnitDTO>))]
        [Route("ingredients")]
        public async Task<ICollection<MeasuringUnitDTO>> GetIngredientsMeasuringUnits()
        {
            return await this.measuringUnitsService.GetIngredientsMeasuringUnits();
        }
    }
}
