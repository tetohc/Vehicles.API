namespace Vehicles.Application.Database.Vehicle.Queries.GetVehicleById
{
    public class GetVehicleByIdModel
    {
        public Guid Id { get; set; }
        public int VehicleTypeCode { get; set; }
        public Guid CarSalespersonId { get; set; }
        public string CarSalespersonName { get; set; }
        public string VehicleType { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool Deleted { get; set; }
    }
}