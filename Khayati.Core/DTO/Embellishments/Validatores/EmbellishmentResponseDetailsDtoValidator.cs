using FluentValidation;

namespace Khayati.Core.DTO.Embellishment.Validatores
{
    public class EmbellishmentResponseDetailsDtoValidator : AbstractValidator<EmellishmentResponseDetailsDto>
    {
        public EmbellishmentResponseDetailsDtoValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Embellishment name is required and this message comes from vadidator");
        }
    }
}
