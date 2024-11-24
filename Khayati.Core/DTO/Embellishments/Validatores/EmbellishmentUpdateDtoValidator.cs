using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khayati.Core.DTO.Embellishments.Validatores
{
    public class EmbellishmentUpdateDtoValidator : AbstractValidator<EmbellishmentUpdateDto>
    {
        public EmbellishmentUpdateDtoValidator( )
        {
                RuleFor(x=>x.Name)
                .NotEmpty()
                .WithMessage("Embellishment name is required and this message comes from vadidator");
        }
    }
}
