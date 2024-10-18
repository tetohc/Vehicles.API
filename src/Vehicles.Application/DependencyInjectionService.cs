using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Vehicles.Application.Configuration;
using Vehicles.Application.Database.CarSalesperson.Queries.GetAllCarSalesperson;
using Vehicles.Application.Database.TypeVehicle.Queries.GetAllVehicleTypes;
using Vehicles.Application.Database.Vehicle.Commands.CreateVehicle;
using Vehicles.Application.Database.Vehicle.Commands.DeleteVehicle;
using Vehicles.Application.Database.Vehicle.Commands.UpdateVehicle;
using Vehicles.Application.Database.Vehicle.Queries.GetAllVehicles;
using Vehicles.Application.Database.Vehicle.Queries.GetVehicleById;
using Vehicles.Application.Validators.Vehicle;

namespace Vehicles.Application
{
    public static class DependencyInjectionService
    {
        /// <summary>
        /// Application layer configuration.
        /// </summary>
        /// <param name="services">Service collection for dependency injection.</param>
        /// <returns>Returns the service collection with the added configurations.</returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            #region Automapper

            var mapper = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperProfile());
            });
            services.AddSingleton(mapper.CreateMapper());

            #endregion Automapper

            #region Vehicle

            services.AddScoped<ICreateVehicleCommand, CreateVehicleCommand>();
            services.AddScoped<IUpdateVehicleCommand, UpdateVehicleCommand>();
            services.AddScoped<IDeleteVehicleCommand, DeleteVehicleCommand>();
            services.AddScoped<IGetVehicleByIdQuery, GetVehicleByIdQuery>();
            services.AddScoped<IGetAllVehiclesQuery, GetAllVehiclesQuery>();

            #endregion Vehicle

            #region CarSalesperson

            services.AddScoped<IGetAllCarSalespersonQuery, GetAllCarSalespersonQuery>();

            #endregion CarSalesperson

            #region VehicleType

            services.AddScoped<IGetAllVehicleTypesQuery, GetAllVehicleTypesQuery>();

            #endregion VehicleType

            #region Validator

            services.AddScoped<IValidator<CreateVehicleModel>, CreateVehicleValidator>();
            services.AddScoped<IValidator<UpdateVehicleModel>, UpdateVehicleValidator>();

            #endregion Validator

            return services;
        }
    }
}