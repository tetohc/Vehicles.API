using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vehicles.Domain.Entities.CarSalesperson;

namespace Vehicles.Persistence.Configuration
{
    public class CarSalespersonConfiguration
    {
        /// <summary>
        /// Configuration for the CarSalesperson entity in the data model.
        /// </summary>
        /// <param name="entityTypeBuilder">Entity type builder for CarSalespersonEntity.</param>
        public CarSalespersonConfiguration(EntityTypeBuilder<CarSalespersonEntity> entityTypeBuilder)
        {
            entityTypeBuilder.Property(e => e.Id).ValueGeneratedNever();
            entityTypeBuilder.Property(e => e.Name).HasMaxLength(100);
        }
    }
}