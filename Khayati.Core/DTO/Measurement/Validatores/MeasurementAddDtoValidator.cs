using FluentValidation;

namespace Khayati.Core.DTO.Measurements.Validatores
{
    public class MeasurementAddDtoValidator:AbstractValidator<MeasurementAddDto>
    {
        public MeasurementAddDtoValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotNull()
                .WithMessage("Customer is required and this message comes from vadidator");
            //.NotEmpty()
            //.WithMessage("Measurements name is required and this message comes from vadidator");

            //    RuleFor(x=>x.Description)
            //        .MaximumLength(5).WithMessage("Description must be less than 5 characterssss");
        }
    }
}
