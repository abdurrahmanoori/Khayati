using FluentValidation;

namespace Khayati.Core.DTO.Customers.Validatores
{
    public class CustomerAddDtoValidator : AbstractValidator<CustomerAddDto>
    {
        public CustomerAddDtoValidator( )
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100);

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\+?\d{7,15}$").WithMessage("Invalid phone format.");

            RuleFor(x => x.DateOfBirth)
                .LessThan(DateTime.Now).WithMessage("Date of birth must be in the past.");
        }
    }
}
