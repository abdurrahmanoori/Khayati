using FluentValidation;

namespace Khayati.Core.DTO.Relative.Validatores
{
    public class RelativeAddDtoValidator:AbstractValidator<RelativeAddDto>
    {
        public RelativeAddDtoValidator()
        {
            RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("Relative name is required and this message comes from vadidator");

            //    RuleFor(x=>x.Description)
            //        .MaximumLength(5).WithMessage("Description must be less than 5 characterssss");
        }
    }
}
