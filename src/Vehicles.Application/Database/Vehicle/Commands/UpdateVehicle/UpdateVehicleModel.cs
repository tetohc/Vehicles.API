namespace Vehicles.Application.Database.Vehicle.Commands.UpdateVehicle
{
    public class UpdateVehicleModel
    {
        public Guid Id { get; set; }
        public int CodeVehicle { get; set; }
        public Guid CarSalespersonId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}