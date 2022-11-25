using System;
using MediatR;

namespace Application.Staff.Commands.DeleteCommand
{
    public class DeleteStaffCommand : IRequest
    {
        public Guid Position { get; set; }
        public Guid Id { get; set; }
    }
}
