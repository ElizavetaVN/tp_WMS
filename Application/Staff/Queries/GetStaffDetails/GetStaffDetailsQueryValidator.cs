using System;
using FluentValidation;

namespace Application.Staff.Queries.GetStaffDetails
{
    public class GetStaffDetailsQueryValidator : AbstractValidator<GetStaffDetailsQuery>
    {
        public GetStaffDetailsQueryValidator()
        {
            RuleFor(staff => staff.Id).NotEqual(Guid.Empty);
            RuleFor(staff => staff.Position).NotEqual(Guid.Empty);
        }
    }
}
