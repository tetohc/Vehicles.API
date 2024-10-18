using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Vehicles.Application.Database.Vehicle.Queries.GetVehicleById
{
    public class GetVehicleByIdQuery : IGetVehicleByIdQuery
    {
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;

        public GetVehicleByIdQuery(IDatabaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }

        public async Task<GetVehicleByIdModel> Execute(Guid vehicleId)
        {
            var entity = await _databaseService.Vehicle
                .Include(x => x.CarSalesperson)
                .Include(x => x.VehicleType)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == vehicleId);

            return _mapper.Map<GetVehicleByIdModel>(entity);
        }
    }
}