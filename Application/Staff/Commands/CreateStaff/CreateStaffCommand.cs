using System;
using MediatR;

namespace Application.Staff.Commands.CreateStaff
{
    public class CreateStaffCommand : IRequest<Guid>
    {
        public Guid Position { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
