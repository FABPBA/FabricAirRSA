using MaterialsAPI.Models;
using MaterialsAPI.Dtos;
using MaterialsAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MaterialsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class MaterialsController : ControllerBase
    {
        private readonly MaterialsService _materialsService;

        public MaterialsController(MaterialsService materialsService)
        {
            _materialsService = materialsService;
        }

        [HttpPost("WireLength")]
        [SwaggerOperation(Description = "The input parameters can only be positive numbers")]
        public ActionResult CalculateWireLength([FromBody] Wire wire)
        {
            var wireLength = _materialsService.CalculateWireLength(wire);

            return Ok(wireLength);
        }

        [HttpPost("Type8")]
        [SwaggerOperation(Description = "The input parameters can only be positive numbers")]
        public ActionResult CalculateMaterialsType8([FromBody] InputDto input)
        {
            var materials = new MaterialsType8();

            var result = _materialsService.CalculateMaterialsType8(input, materials);

            return Ok(result);
        }
    }
}

