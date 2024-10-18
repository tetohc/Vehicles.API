namespace Vehicles.Application.Database.TypeVehicle.Queries.GetAllVehicleTypes
{
    public interface IGetAllVehicleTypesQuery
    {
        Task<List<GetAllVehicleTypesModel>> Execute();
    }
}