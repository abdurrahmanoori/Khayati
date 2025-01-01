using FluentValidation;

namespace Khayati.Core.DTO.Relative.Validatores
{
    public class RelativeUpdateDtoValidator : AbstractValidator<RelativeUpdateDto>
    {
        public RelativeUpdateDtoValidator( )
        {
                RuleFor(x=>x.FirstName)
                .NotEmpty()
                .WithMessage("Relative name is required and this message comes from vadidator");
        }
    }
}
