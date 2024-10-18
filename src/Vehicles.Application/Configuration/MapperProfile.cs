using AutoMapper;
using Vehicles.Application.Database.CarSalesperson.Queries.GetAllCarSalesperson;
using Vehicles.Application.Database.TypeVehicle.Queries.GetAllVehicleTypes;
using Vehicles.Application.Database.Vehicle.Commands.CreateVehicle;
using Vehicles.Application.Database.Vehicle.Commands.UpdateVehicle;
using Vehicles.Application.Database.Vehicle.Queries.GetAllVehicles;
using Vehicles.Application.Database.Vehicle.Queries.GetVehicleById;
using Vehicles.Domain.Entities.CarSalesperson;
using Vehicles.Domain.Entities.TypeVehicle;
using Vehicles.Domain.Entities.Vehicle;

namespace Vehicles.Application.Configuration
{
    /// <summary>
    /// Provide organization and settings for the mappers between different types of objects.
    /// </summary>
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region Vehicle

            CreateMap<VehicleEntity, CreateVehicleModel>().ReverseMap();
            CreateMap<VehicleEntity, UpdateVehicleModel>().ReverseMap();
            CreateMap<VehicleEntity, GetAllVehiclesModel>().ReverseMap();
            CreateMap<VehicleEntity, GetVehicleByIdModel>()
                .ForMember(x => x.VehicleTypeCode, options => options.MapFrom(vehicle => vehicle.VehicleType.Code))
                .ForMember(x => x.VehicleType, options => options.MapFrom(vehicle => vehicle.VehicleType.Description.Trim()))
                .ForMember(x => x.CarSalespersonName, options => options.MapFrom(vehicle => vehicle.CarSalesperson.Name.Trim()))
                .ReverseMap();

            #endregion Vehicle

            #region CarSalesperson

            CreateMap<CarSalespersonEntity, GetAllCarSalespersonModel>().ReverseMap();

            #endregion CarSalesperson

            #region VehicleType

            CreateMap<VehicleTypeEntity, GetAllVehicleTypesModel>().ReverseMap();

            #endregion VehicleType
        }
    }
}