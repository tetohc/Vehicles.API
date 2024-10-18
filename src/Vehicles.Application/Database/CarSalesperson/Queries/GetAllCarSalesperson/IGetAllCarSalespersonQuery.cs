namespace Vehicles.Application.Database.CarSalesperson.Queries.GetAllCarSalesperson
{
    public interface IGetAllCarSalespersonQuery
    {
        Task<List<GetAllCarSalespersonModel>> Execute();
    }
}