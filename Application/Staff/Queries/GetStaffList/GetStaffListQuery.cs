using System;
using MediatR;

namespace Application.Staff.Queries.GetStaffList
{
    public class GetStaffListQuery : IRequest<StaffListVm>//класс запроса
    {
        public Guid Position { get; set; }
    }
}
