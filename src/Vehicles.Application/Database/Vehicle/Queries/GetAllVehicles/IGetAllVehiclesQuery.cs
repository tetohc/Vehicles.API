namespace Vehicles.Application.Database.Vehicle.Queries.GetAllVehicles
{
    public interface IGetAllVehiclesQuery
    {
        Task<List<GetAllVehiclesModel>> Execute();
    }
}