using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khayati.Core.DTO.Embellishment.Validatores
{
    public class EmbellishmentResponseDetailsDtoValidator:AbstractValidator<EmellishmentResponseDetailsDto>
    {
        public EmbellishmentResponseDetailsDtoValidator()
        {
                RuleFor(x=>x.EmbellishmentName)
                .NotEmpty()
                .WithMessage("Embellishment name is required and this message comes from vadidator");
        }
    }
}
