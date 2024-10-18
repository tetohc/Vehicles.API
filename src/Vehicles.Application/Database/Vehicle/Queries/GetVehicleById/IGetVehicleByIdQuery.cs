namespace Vehicles.Application.Database.Vehicle.Queries.GetVehicleById
{
    public interface IGetVehicleByIdQuery
    {
        Task<GetVehicleByIdModel> Execute(Guid vehicleId);
    }
}