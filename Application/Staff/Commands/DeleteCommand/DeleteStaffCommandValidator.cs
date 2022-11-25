using System;
using FluentValidation;

namespace Application.Staff.Commands.DeleteCommand
{
    public class DeleteStaffCommandValidator : AbstractValidator<DeleteStaffCommand>
    {
        public DeleteStaffCommandValidator()
        {
            RuleFor(deleteStaffCommand => deleteStaffCommand.Id).NotEqual(Guid.Empty);
            RuleFor(deleteStaffCommand => deleteStaffCommand.Position).NotEqual(Guid.Empty);
        }
    }
}
