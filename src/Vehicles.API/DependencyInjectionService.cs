using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Vehicles.API
{
    /// <summary>
    /// Provides methods for configuring swagger and other essential services for this API.
    /// </summary>
    public static class DependencyInjectionService
    {
        /// <summary>
        /// Provide API configuration settings.
        /// </summary>
        /// <param name="services">Service collection for dependency injection.</param>
        /// <returns>Returns the service collection with the added configurations.</returns>
        public static IServiceCollection AddWebApi(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Vehicles API",
                    Description = "APIs for vehicle management with CRUD operations.",
                    Contact = new OpenApiContact
                    {
                        Name = "Jerry Hurtado",
                        Email = "",
                        Url = new Uri("https://www.google.com")
                    }
                });

                var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, fileName));
            });
            return services;
        }
    }
}