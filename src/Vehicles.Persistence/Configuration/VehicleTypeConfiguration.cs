using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vehicles.Domain.Entities.TypeVehicle;

namespace Vehicles.Persistence.Configuration
{
    public class VehicleTypeConfiguration
    {
        /// <summary>
        /// Configuration for the VehicleType entity in the data model.
        /// </summary>
        /// <param name="entityTypeBuilder">Entity type builder for VehicleType.</param>
        public VehicleTypeConfiguration(EntityTypeBuilder<VehicleTypeEntity> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(e => e.Code);
            entityTypeBuilder.Property(e => e.Description).HasMaxLength(50);
        }
    }
}