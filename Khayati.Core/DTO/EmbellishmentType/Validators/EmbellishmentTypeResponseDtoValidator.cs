using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khayati.Core.DTO.EmbellishmentType.Validators
{
    public class EmbellishmentTypeResponseDtoValidator : AbstractValidator<EmbellishmentTypeResponseDto>
    {
        public EmbellishmentTypeResponseDtoValidator()
        {
            //RuleFor(x=> x.Name)
            //    .NotEmpty().WithMessage("Name is required.")
            //    .NotNull().WithMessage("Name cannot be null.")
            //    .MaximumLength(3).WithMessage("Name cannot exceed 100 characters.");

            //RuleFor(x => x.SortOrder)
            //    .NotNull()
            //    .NotEmpty();
        }
    }
}
