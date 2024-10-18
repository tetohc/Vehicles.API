namespace Vehicles.Application.Database.Vehicle.Commands.UpdateVehicle
{
    public interface IUpdateVehicleCommand
    {
        Task<UpdateVehicleModel> Execute(UpdateVehicleModel model);
    }
}