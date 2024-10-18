using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Vehicles.Application.Database.Vehicle.Queries.GetAllVehicles
{
    public class GetAllVehiclesQuery : IGetAllVehiclesQuery
    {
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;

        public GetAllVehiclesQuery(IDatabaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }

        public async Task<List<GetAllVehiclesModel>> Execute()
        {
            var entities = await _databaseService.Vehicle.Where(x => !x.Deleted)
                .OrderByDescending(x => x.RegistrationDate)
                .ToListAsync();
            
            return _mapper.Map<List<GetAllVehiclesModel>>(entities);
        }
    }
}