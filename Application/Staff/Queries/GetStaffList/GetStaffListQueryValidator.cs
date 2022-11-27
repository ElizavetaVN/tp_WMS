using System;
using FluentValidation;

namespace Application.Staff.Queries.GetStaffList
{
    public class GetStaffListQueryValidator : AbstractValidator<GetStaffListQuery>
    {
        public GetStaffListQueryValidator()
        {
            RuleFor(x => x.Position).NotEqual(Guid.Empty);
        }
    }
}
