using Microsoft.AspNetCore.Mvc;
using Vehicles.Application.Database.CarSalesperson.Queries.GetAllCarSalesperson;
using Vehicles.Application.Features;

namespace Vehicles.API.Controllers
{
    /// <summary>
    /// Controller for car salesperson.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CarSalesPersonsController : ControllerBase
    {
        /// <summary>
        /// Retrieves a list of all car salespersons.
        /// </summary>
        /// <param name="getAllCarSalespersonQuery">Query to get all car salesperson.</param>
        /// <returns>Response to the request.</returns>
        [HttpGet("Get-All")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetAllCarSalespersonModel>))]
        public async Task<IActionResult> GetAllAsync([FromServices] IGetAllCarSalespersonQuery getAllCarSalespersonQuery)
        {
            var data = await getAllCarSalespersonQuery.Execute();
            return StatusCode(statusCode: StatusCodes.Status200OK,
                value: ResponseApiService.Response(statusCode: StatusCodes.Status200OK, data: data));
        }
    }
}