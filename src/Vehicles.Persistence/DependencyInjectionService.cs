using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vehicles.Application.Database;
using Vehicles.Persistence.Database;

namespace Vehicles.Persistence
{
    public static class DependencyInjectionService
    {
        /// <summary>
        /// Persistence layer configuration.
        /// </summary>
        /// <param name="services">Service collection for dependency injection.</param>
        /// <param name="configuration">Application configuration to retrieve connection string.</param>
        /// <returns>Returns the service collection with the added configurations.</returns>
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseService>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SQLConnectionString"));
            });

            services.AddScoped<IDatabaseService, DatabaseService>();
            return services;
        }
    }
}