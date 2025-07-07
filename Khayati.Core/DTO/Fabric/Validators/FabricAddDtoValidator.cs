using FluentValidation;
using System;

namespace Khayati.Core.DTO.Fabric.Validators
{
    public class FabricAddDtoValidator : AbstractValidator<FabricAddDto>
    {
        public FabricAddDtoValidator()
        {
            RuleFor(x => x.FabricType)
                .NotEmpty().WithMessage("Fabric type is required.")
                .MaximumLength(100);

            RuleFor(x => x.Color)
                .NotEmpty().WithMessage("Color is required.")
                .MaximumLength(50);

            RuleFor(x => x.RequiredMeters)
                .GreaterThan(0).WithMessage("Required meters must be greater than 0.");

            RuleFor(x => x.Pattern)
                .NotEmpty().WithMessage("Pattern is required.")
                .MaximumLength(100);

            RuleFor(x => x.Durability)
                .NotEmpty().WithMessage("Durability is required.")
                .MaximumLength(100);

            RuleFor(x => x.CostPerMeter)
                .GreaterThan(0).WithMessage("Cost per meter must be greater than 0.");
        }
    }
}
