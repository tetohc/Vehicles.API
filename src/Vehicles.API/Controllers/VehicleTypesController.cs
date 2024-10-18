using Microsoft.AspNetCore.Mvc;
using Vehicles.Application.Database.TypeVehicle.Queries.GetAllVehicleTypes;
using Vehicles.Application.Features;

namespace Vehicles.API.Controllers
{
    /// <summary>
    /// Controller for car VehicleType.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class VehicleTypesController : ControllerBase
    {
        /// <summary>
        /// Retrieves a list of all vehicle types.
        /// </summary>
        /// <param name="getAllVehicleTypesQuery">Query to get all vehicle types.</param>
        /// <returns>Response to the request.</returns>
        [HttpGet("Get-All")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<IGetAllVehicleTypesQuery>))]
        public async Task<IActionResult> GetAllAsync([FromServices] IGetAllVehicleTypesQuery getAllVehicleTypesQuery)
        {
            var data = await getAllVehicleTypesQuery.Execute();
            return StatusCode(statusCode: StatusCodes.Status200OK,
                value: ResponseApiService.Response(statusCode: StatusCodes.Status200OK, data: data));
        }
    }
}