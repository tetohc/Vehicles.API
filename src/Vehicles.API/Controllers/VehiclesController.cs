using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Vehicles.Application.Database.Vehicle.Commands.CreateVehicle;
using Vehicles.Application.Database.Vehicle.Commands.DeleteVehicle;
using Vehicles.Application.Database.Vehicle.Commands.UpdateVehicle;
using Vehicles.Application.Database.Vehicle.Queries.GetAllVehicles;
using Vehicles.Application.Database.Vehicle.Queries.GetVehicleById;
using Vehicles.Application.Exceptions;
using Vehicles.Application.Features;
using Vehicles.Application.Utilities;
using Vehicles.Domain.Enums;

namespace Vehicles.API.Controllers
{
    /// <summary>
    /// Controller for vehicle management.
    /// Provide CRUD operations for the vehicle.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [Produces("application/json")]
    [TypeFilter(typeof(ExceptionManager))]
    public class VehiclesController : ControllerBase
    {
        /// <summary>
        /// Create a new vehicle.
        /// </summary>
        /// <param name="vehicleModel">Vehicle object.</param>
        /// <param name="createVehicleCommand">Command to create the vehicle.</param>
        /// <param name="validator">Vehicle model validator.</param>
        /// <returns>Response to the request.</returns>
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateVehicleModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseApiService))]
        public async Task<IActionResult> Create(
            [FromBody] CreateVehicleModel vehicleModel,
            [FromServices] ICreateVehicleCommand createVehicleCommand,
            [FromServices] IValidator<CreateVehicleModel> validator
            )
        {
            var validate = await validator.ValidateAsync(vehicleModel);
            if (!validate.IsValid)
                return StatusCode(statusCode: StatusCodes.Status400BadRequest,
                    value: ResponseApiService.Response(statusCode: StatusCodes.Status400BadRequest, data: validate.Errors));

            var data = await createVehicleCommand.Execute(vehicleModel);
            return StatusCode(statusCode: StatusCodes.Status201Created,
                value: ResponseApiService.Response(statusCode: StatusCodes.Status201Created, data: data));
        }

        /// <summary>
        /// Updates the information of an existing vehicle.
        /// </summary>
        /// <param name="updateVehicleModel">Model containing the update vehicle data.</param>
        /// <param name="updateVehicleCommand">Command to execute the vehicle update.</param>
        /// <param name="getVehicleByIdQuery">Query to get the vehicle by its ID.</param>
        /// <param name="validator">Validator for the vehicle update model.</param>
        /// <returns>Response to the request.</returns>
        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateVehicleModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseApiService))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseApiService))]
        public async Task<IActionResult> Update
            (
                [FromBody] UpdateVehicleModel updateVehicleModel,
                [FromServices] IUpdateVehicleCommand updateVehicleCommand,
                [FromServices] IGetVehicleByIdQuery getVehicleByIdQuery,
                [FromServices] IValidator<UpdateVehicleModel> validator
            )
        {
            var validate = await validator.ValidateAsync(updateVehicleModel);
            if (!validate.IsValid)
                return StatusCode(statusCode: StatusCodes.Status400BadRequest,
                    value: ResponseApiService.Response(statusCode: StatusCodes.Status400BadRequest, data: validate.Errors));

            var entity = await getVehicleByIdQuery.Execute(updateVehicleModel.Id);
            if (entity == null)
                return base.StatusCode(statusCode: StatusCodes.Status404NotFound,
                    value: ResponseApiService.Response(statusCode: StatusCodes.Status404NotFound,
                    message: EnumsExtensions.GetDisplayName(ErrorMessages.VehicleNotFound)));

            var data = await updateVehicleCommand.Execute(updateVehicleModel);
            return StatusCode(statusCode: StatusCodes.Status200OK,
                value: ResponseApiService.Response(statusCode: StatusCodes.Status200OK, data: data));
        }

        /// <summary>
        /// Deletes a vehicle by its ID.
        /// </summary>
        /// <param name="vehicleId">Unique identifier of the vehicle.</param>
        /// <param name="deleteVehicleCommand">Command to execute the vehicle deletion.</param>
        /// <returns>Response to the request.</returns>
        [HttpDelete("Delete/{vehicleId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseApiService))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseApiService))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(ResponseApiService))]
        public async Task<IActionResult> Delete(Guid vehicleId, [FromServices] IDeleteVehicleCommand deleteVehicleCommand)
        {
            if (vehicleId == Guid.Empty)
                return base.StatusCode(statusCode: StatusCodes.Status400BadRequest,
                    value: ResponseApiService.Response(statusCode: StatusCodes.Status400BadRequest,
                    message: EnumsExtensions.GetDisplayName(ErrorMessages.VehicleIdCannotBeNull)));

            var result = await deleteVehicleCommand.Execute(vehicleId);
            if (!result)
                return base.StatusCode(statusCode: StatusCodes.Status404NotFound,
                    value: ResponseApiService.Response(statusCode: StatusCodes.Status404NotFound,
                    message: EnumsExtensions.GetDisplayName(ErrorMessages.VehicleNotFound)));

            return StatusCode(statusCode: StatusCodes.Status204NoContent,
                value: ResponseApiService.Response(statusCode: StatusCodes.Status200OK));
        }

        /// <summary>
        /// Retrieves vehicle information by its ID.
        /// </summary>
        /// <param name="vehicleId">Unique identifier of the vehicle.</param>
        /// <param name="getVehicleByIdQuery">Query to get vehicle information by its ID.</param>
        /// <returns>Response to the request.</returns>
        [HttpGet("Get-by-Id/{vehicleId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseApiService))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseApiService))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetVehicleByIdModel))]
        public async Task<IActionResult> GetById(Guid vehicleId, [FromServices] IGetVehicleByIdQuery getVehicleByIdQuery)
        {
            if (vehicleId == Guid.Empty)
                return base.StatusCode(statusCode: StatusCodes.Status400BadRequest,
                    value: ResponseApiService.Response(statusCode: StatusCodes.Status400BadRequest,
                    message: EnumsExtensions.GetDisplayName(ErrorMessages.VehicleIdCannotBeNull)));

            var data = await getVehicleByIdQuery.Execute(vehicleId);
            if (data == null)
                return base.StatusCode(statusCode: StatusCodes.Status404NotFound,
                    value: ResponseApiService.Response(statusCode: StatusCodes.Status404NotFound,
                    message: EnumsExtensions.GetDisplayName(ErrorMessages.VehicleNotFound)));

            return StatusCode(statusCode: StatusCodes.Status200OK,
                value: ResponseApiService.Response(statusCode: StatusCodes.Status200OK, data: data));
        }

        /// <summary>
        /// Retrieve a list of all vehicles.
        /// </summary>
        /// <param name="getAllVehiclesQuery">Query to get all vehicles.</param>
        /// <returns>Response to the request.</returns>
        [HttpGet("Get-All")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetAllVehiclesModel>))]
        public async Task<IActionResult> GetAllAsync([FromServices] IGetAllVehiclesQuery getAllVehiclesQuery)
        {
            var data = await getAllVehiclesQuery.Execute();

            return StatusCode(statusCode: StatusCodes.Status200OK,
                value: ResponseApiService.Response(statusCode: StatusCodes.Status200OK, data: data));
        }
    }
}