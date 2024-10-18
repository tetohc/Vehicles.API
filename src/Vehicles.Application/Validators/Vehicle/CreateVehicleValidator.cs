using FluentValidation;
using Vehicles.Application.Database.Vehicle.Commands.CreateVehicle;

namespace Vehicles.Application.Validators.Vehicle
{
    public class CreateVehicleValidator : AbstractValidator<CreateVehicleModel>
    {
        public CreateVehicleValidator()
        {
            RuleFor(x => x.TypeVehicleCode).GreaterThanOrEqualTo(0);
            RuleFor(x => x.CarSalespersonId).NotEmpty();
            RuleFor(x => x.Model).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Brand).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Quantity).GreaterThan(0);
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
        }
    }
}