# Mantenimiento de Vehículos API

## Descripción
Este proyecto es una API desarrollada en .NET 8 que implementa un CRUD para el mantenimiento de vehículos y vendedores. La arquitectura del proyecto sigue los principios de Clean Architecture y utiliza CQRS (Command Query Responsibility Segregation) para separar las operaciones de lectura y escritura. Además, se han implementado inyección de dependencias, validaciones con FluentValidation y mapeo de objetos con AutoMapper.

**Nota**: Si clonas este repositorio, debes agregar tu propia cadena de conexión a la base de datos SQL Server en `appsettings.json`.

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
