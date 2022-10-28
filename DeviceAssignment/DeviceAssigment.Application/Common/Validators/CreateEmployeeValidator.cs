using DeviceAssigment.Application.Employee.Dtos;
using FluentValidation;

namespace DeviceAssigment.Application.Common.Validators
{
    public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeDto>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(f => f.FirstName)
                .NotEmpty().WithMessage("First Name is required");

            RuleFor(l => l.LastName)
                .NotEmpty().WithMessage("Last Name is required");

            RuleFor(p => p.Position)
                .NotEmpty().WithMessage("Position is required.");

            RuleFor(m => m.MobileNo)
                .NotEmpty().WithMessage("Mobile No. is required.")
                .Matches("^[0-9]*$").WithMessage("Invalid Mobile No.");
    
            RuleFor(e => e.EmploymentDate)
                .NotEmpty().WithMessage("Employment Date is required.");
        }
    }
}