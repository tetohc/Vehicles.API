using Vehicles.Domain.Entities.CarSalesperson;
using Vehicles.Domain.Entities.TypeVehicle;

namespace Vehicles.Domain.Entities.Vehicle
{
    public class VehicleEntity
    {
        public Guid Id { get; set; }
        public int VehicleTypeCode { get; set; }
        public Guid CarSalespersonId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool Deleted { get; set; }
        public virtual VehicleTypeEntity VehicleType { get; set; }
        public virtual CarSalespersonEntity CarSalesperson { get; set; }
    }
}