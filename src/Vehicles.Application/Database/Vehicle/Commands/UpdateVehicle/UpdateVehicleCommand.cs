using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Transactions;
using Vehicles.Domain.Entities.Vehicle;

namespace Vehicles.Application.Database.Vehicle.Commands.UpdateVehicle
{
    public class UpdateVehicleCommand : IUpdateVehicleCommand
    {
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;

        public UpdateVehicleCommand(IDatabaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }

        public async Task<UpdateVehicleModel> Execute(UpdateVehicleModel model)
        {
            var oldEntity = await _databaseService.Vehicle.AsNoTracking().FirstOrDefaultAsync(x => x.Id == model.Id);

            var entity = _mapper.Map<VehicleEntity>(model);
            entity.RegistrationDate = oldEntity.RegistrationDate;
            entity.Deleted = oldEntity.Deleted;

            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                _databaseService.Vehicle.Update(entity);
                await _databaseService.SaveAsync();
                transaction.Complete();
            }
            return model;
        }
    }
}