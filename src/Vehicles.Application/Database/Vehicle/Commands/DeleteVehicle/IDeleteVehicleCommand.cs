namespace Vehicles.Application.Database.Vehicle.Commands.DeleteVehicle
{
    public interface IDeleteVehicleCommand
    {
        Task<bool> Execute(Guid vehicleId);
    }
}