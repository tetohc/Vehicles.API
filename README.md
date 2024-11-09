# Vehicles.API

## Descripción

Este proyecto es una API desarrollada en .NET 8 que implementa operaciones CRUD para la gestión de vehículos y vendedores. La arquitectura sigue los principios de Clean Architecture y emplea CQRS (Command Query Responsibility Segregation) para separar las operaciones de lectura y escritura. Además, se utiliza inyección de dependencias, validaciones con FluentValidation y mapeo de objetos con AutoMapper para asegurar un código limpio y mantenible.

## Características

- **CRUD Completo**: Operaciones de creación, lectura, actualización y eliminación para vehículos y vendedores.
- **Arquitectura Limpia**: Separación de responsabilidades en capas bien definidas.
- **CQRS**: Separación de comandos y consultas para mejorar la escalabilidad y mantenibilidad.
- **Inyección de Dependencias**: Uso de inyección de dependencias para gestionar las dependencias de manera eficiente.
- **Validaciones**: Implementación de validaciones utilizando FluentValidation.
- **AutoMapper**: Mapeo automático de objetos para simplificar la conversión entre entidades y DTOs.

## Tecnologías Utilizadas

- **Lenguaje de Programación**: C#
- **Framework**: .NET 8
- **ORM**: Entity Framework Core
- **Validación**: FluentValidation
- **Mapeo de Objetos**: AutoMapper
- **Documentación de la API**: Swagger

## Endpoints

### CarSalesPersons

- **GET** `/api/CarSalesPersons/Get-All`: Recupera una lista de todos los vendedores.

### Vehicles

- **POST** `/Vehicles/Create`: Crea un nuevo vehículo.
- **PUT** `/Vehicles/Update`: Actualiza la información de un vehículo existente.
- **DELETE** `/Vehicles/Delete/{vehicleId}`: Elimina un vehículo por su ID.
- **GET** `/Vehicles/Get-by-Id/{vehicleId}`: Recupera la información de un vehículo por su ID.
- **GET** `/Vehicles/Get-All`: Recupera una lista de todos los vehículos.

### VehicleTypes

- **GET** `/VehicleTypes/Get-All`: Recupera una lista de todos los tipos de vehículos.

## Esquemas

El proyecto incluye los siguientes esquemas:

- **BaseResponseModel**
- **CreateVehicleModel**
- **GetAllCarSalespersonModel**
- **GetAllVehiclesModel**
- **GetVehicleByIdModel**
- **IGetAllVehicleTypesQuery**
- **UpdateVehicleModel**
