using Vehicles.Domain.Entities.Vehicle;

namespace Vehicles.Domain.Entities.TypeVehicle
{
    public class VehicleTypeEntity
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public virtual ICollection<VehicleEntity> Vehicles { get; set; } = new List<VehicleEntity>();
    }
}