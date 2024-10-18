using Microsoft.EntityFrameworkCore;
using Vehicles.Application.Database;
using Vehicles.Domain.Entities.CarSalesperson;
using Vehicles.Domain.Entities.TypeVehicle;
using Vehicles.Domain.Entities.Vehicle;
using Vehicles.Persistence.Configuration;

namespace Vehicles.Persistence.Database
{
    public class DatabaseService : DbContext, IDatabaseService
    {
        public DatabaseService(DbContextOptions options) : base(options)
        {
        }

        public DbSet<VehicleEntity> Vehicle { get; set; }
        public DbSet<VehicleTypeEntity> VehicleType { get; set; }
        public DbSet<CarSalespersonEntity> CarSalesperson { get; set; }

        public async Task<bool> SaveAsync() => await SaveChangesAsync() > 0;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfiguration(modelBuilder);
        }

        private void EntityConfiguration(ModelBuilder modelBuilder)
        {
            new VehicleConfiguration(modelBuilder.Entity<VehicleEntity>());
            new VehicleTypeConfiguration(modelBuilder.Entity<VehicleTypeEntity>());
            new CarSalespersonConfiguration(modelBuilder.Entity<CarSalespersonEntity>());
        }
    }
}