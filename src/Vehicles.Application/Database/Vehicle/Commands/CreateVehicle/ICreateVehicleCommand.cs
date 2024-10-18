namespace Vehicles.Application.Database.Vehicle.Commands.CreateVehicle
{
    public interface ICreateVehicleCommand
    {
        Task<CreateVehicleModel> Execute(CreateVehicleModel model);
    }
}