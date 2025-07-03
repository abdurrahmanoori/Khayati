using FluentValidation;

namespace Khayati.Core.DTO.Garment.Validatores
{
    public class GarmentAddDtoValidator : AbstractValidator<GarmentAddDto>
    {
        public GarmentAddDtoValidator( )
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100);

            RuleFor(x => x.Cost)
                .GreaterThan(0).WithMessage("Cost must be greater than zero.");
        }
    }
}
