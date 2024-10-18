using FluentValidation;
using Vehicles.Application.Database.Vehicle.Commands.UpdateVehicle;

namespace Vehicles.Application.Validators.Vehicle
{
    public class UpdateVehicleValidator : AbstractValidator<UpdateVehicleModel>
    {
        public UpdateVehicleValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.CodeVehicle).GreaterThanOrEqualTo(0);
            RuleFor(x => x.CarSalespersonId).NotEmpty();
            RuleFor(x => x.Model).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Brand).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Quantity).GreaterThan(0);
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
        }
    }
}