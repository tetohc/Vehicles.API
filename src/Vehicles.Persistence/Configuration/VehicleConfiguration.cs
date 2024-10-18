using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vehicles.Domain.Entities.Vehicle;

namespace Vehicles.Persistence.Configuration
{
    public class VehicleConfiguration
    {
        /// <summary>
        ///  Configuration for the Vehicle entity in the data model.
        /// </summary>
        /// <param name="entityTypeBuilder">Entity type builder for VehicleEntity.</param>
        public VehicleConfiguration(EntityTypeBuilder<VehicleEntity> entityTypeBuilder)
        {
            entityTypeBuilder.Property(e => e.Id).ValueGeneratedNever();
            entityTypeBuilder.Property(e => e.RegistrationDate).HasColumnType("datetime").IsRequired();
            entityTypeBuilder.Property(e => e.Brand).HasMaxLength(50).IsRequired();
            entityTypeBuilder.Property(e => e.Model).HasMaxLength(50).IsRequired();
            entityTypeBuilder.Property(e => e.Price).HasColumnType("decimal(18, 2)").IsRequired();

            entityTypeBuilder.HasOne(d => d.VehicleType).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.VehicleTypeCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vehicle_VehicleType");

            entityTypeBuilder.HasOne(d => d.CarSalesperson).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.CarSalespersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vehicle_CarSalesperson");
        }
    }
}