namespace Vehicles.Application.Database.Vehicle.Commands.CreateVehicle
{
    public class CreateVehicleModel
    {
        public int TypeVehicleCode { get; set; }
        public Guid CarSalespersonId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}