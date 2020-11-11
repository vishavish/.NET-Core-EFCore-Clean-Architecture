using DeviceAssigment.Application.Device.Dtos;
using FluentValidation;

namespace DeviceAssigment.Application.Common.Validators
{
    public class CreateDeviceValidator : AbstractValidator<CreateDeviceDto>
    {
        public CreateDeviceValidator()
        {
            RuleFor(n => n.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Length must not be more than 100 characters.");

            RuleFor(d => d.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(255).WithMessage("Description must not be more than 255 characters.");

            RuleFor(c => c.Condition)
                .IsInEnum();
        }
    }
}