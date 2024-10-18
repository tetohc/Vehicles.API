using Vehicles.Domain.Entities.Vehicle;

namespace Vehicles.Domain.Entities.CarSalesperson
{
    public class CarSalespersonEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<VehicleEntity> Vehicles { get; set; } = new List<VehicleEntity>();
    }
}