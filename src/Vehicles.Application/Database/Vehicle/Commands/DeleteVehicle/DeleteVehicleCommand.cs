using Microsoft.EntityFrameworkCore;

namespace Vehicles.Application.Database.Vehicle.Commands.DeleteVehicle
{
    public class DeleteVehicleCommand : IDeleteVehicleCommand
    {
        private readonly IDatabaseService _databaseService;

        public DeleteVehicleCommand(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<bool> Execute(Guid vehicleId)
        {
            var entity = await _databaseService.Vehicle.FirstOrDefaultAsync(x => x.Id == vehicleId);

            if (entity == null)
                return false;

            _databaseService.Vehicle.Remove(entity);
            return await _databaseService.SaveAsync();
        }
    }
}