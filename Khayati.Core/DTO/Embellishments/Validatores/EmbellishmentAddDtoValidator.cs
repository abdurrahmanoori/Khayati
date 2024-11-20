using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khayati.Core.DTO.Embellishments.Validatores
{
    public class EmbellishmentAddDtoValidator:AbstractValidator<EmbellishmentAddDto>
    {
        public EmbellishmentAddDtoValidator()
        {
            //        RuleFor(x=>x.Name)
            //        .NotEmpty()
            //        .WithMessage("Embellishment name is required and this message comes from vadidator");

            //    RuleFor(x=>x.Description)
            //        .MaximumLength(5).WithMessage("Description must be less than 5 characterssss");
        }
    }
}
