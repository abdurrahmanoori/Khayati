using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khayati.Core.DTO.EmbellishmentType.Validators
{
    public class EmbellishmentTypeAddDtoValidator : AbstractValidator<EmbellishmentTypeAddDto>
    {
        public EmbellishmentTypeAddDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty. fluent valdiaton.")
                .NotNull().WithMessage("Name cannot be null. fluent valdiaton")
                .MaximumLength(100)
                .WithMessage("Name cannot exceed 100 characters.fluent valdiaton");

            RuleFor(x => x.SortOrder)
                .NotNull()
                .NotEmpty();
        }
    }
}
