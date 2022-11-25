using System;
using FluentValidation;

namespace Application.Staff.Commands.UpdateStaff
{
    public class UpdateStaffCommandValidator : AbstractValidator<UpdateStaffCommand>
    {
        public UpdateStaffCommandValidator()
        {
            RuleFor(updateNoteCommand => updateNoteCommand.Position).NotEqual(Guid.Empty);
            RuleFor(updateNoteCommand => updateNoteCommand.Id).NotEqual(Guid.Empty);

        }
    }
}
