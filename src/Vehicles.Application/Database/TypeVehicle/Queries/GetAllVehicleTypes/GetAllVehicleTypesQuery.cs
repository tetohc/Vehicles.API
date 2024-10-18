using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Vehicles.Application.Database.TypeVehicle.Queries.GetAllVehicleTypes
{
    public class GetAllVehicleTypesQuery : IGetAllVehicleTypesQuery
    {
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;

        public GetAllVehicleTypesQuery(IDatabaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }

        public async Task<List<GetAllVehicleTypesModel>> Execute()
        {
            var entities = await _databaseService.VehicleType.ToListAsync();
            return _mapper.Map<List<GetAllVehicleTypesModel>>(entities);
        }
    }
}