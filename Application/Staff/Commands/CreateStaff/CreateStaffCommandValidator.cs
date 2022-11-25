using System;
using FluentValidation;

namespace Application.Staff.Commands.CreateStaff
{
    public class CreateStaffCommandValidator : AbstractValidator<CreateStaffCommand>
    {
        public CreateStaffCommandValidator()
        {
            RuleFor(createStaffCommand =>
                createStaffCommand.Position).NotEqual(Guid.Empty);
        }
    }
}
