using System;
using MediatR;

namespace Application.Staff.Queries.GetStaffDetails
{
    public class GetStaffDetailsQuery : IRequest<StaffDetailsVm>//получение параметров сотрудника
    {
        public Guid Position { get; set; }
        public Guid Id { get; set; }
    }
}
