using System;
using MediatR;

namespace Application.Staff.Commands.UpdateStaff
{
    public  class UpdateStaffCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid Position { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
