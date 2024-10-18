using AutoMapper;
using System.Transactions;
using Vehicles.Domain.Entities.Vehicle;

namespace Vehicles.Application.Database.Vehicle.Commands.CreateVehicle
{
    public class CreateVehicleCommand : ICreateVehicleCommand
    {
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;

        public CreateVehicleCommand(IDatabaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }

        public async Task<CreateVehicleModel> Execute(CreateVehicleModel model)
        {
            var entity = _mapper.Map<VehicleEntity>(model);
            entity.Id = Guid.NewGuid();
            entity.RegistrationDate = DateTime.Now;
            entity.Deleted = false;

            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await _databaseService.Vehicle.AddAsync(entity);
                await _databaseService.SaveAsync();
                transaction.Complete();
            }
            return model;
        }
    }
}