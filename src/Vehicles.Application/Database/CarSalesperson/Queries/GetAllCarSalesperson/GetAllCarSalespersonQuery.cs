using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Vehicles.Application.Database.CarSalesperson.Queries.GetAllCarSalesperson
{
    public class GetAllCarSalespersonQuery : IGetAllCarSalespersonQuery
    {
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;

        public GetAllCarSalespersonQuery(IDatabaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }

        public async Task<List<GetAllCarSalespersonModel>> Execute()
        {
            var entities = await _databaseService.CarSalesperson.ToListAsync();
            return _mapper.Map<List<GetAllCarSalespersonModel>>(entities);
        }
    }
}