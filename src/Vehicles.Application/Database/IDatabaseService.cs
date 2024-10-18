using Microsoft.EntityFrameworkCore;
using Vehicles.Domain.Entities.CarSalesperson;
using Vehicles.Domain.Entities.TypeVehicle;
using Vehicles.Domain.Entities.Vehicle;

namespace Vehicles.Application.Database
{
    public interface IDatabaseService
    {
        DbSet<CarSalespersonEntity> CarSalesperson { get; set; }
        DbSet<VehicleTypeEntity> VehicleType { get; set; }
        DbSet<VehicleEntity> Vehicle { get; set; }

        Task<bool> SaveAsync();
    }
}