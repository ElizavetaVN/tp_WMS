using Application.Features.RegistrationWriteTypeFeatures.Queries;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.RegistrationWriteFeatures.Commands
{
    public class CreateRegistrationWriteCommand : IRequest<RegistrationWrite>
    {
        public int RegistrationWriteType { get; set; }
        public bool Status { get; set; }
        public int Inventory { get; set; }
        public int Warehouses { get; set; }
        public int Products { get; set; }
        public string Quantity { get; set; }
        public Units Units { get; set; }
        public DateTime Data { get; set; }
        public string Employee { get; set; }

        public class CreateRegistrationWriteCommandHandler : IRequestHandler<CreateRegistrationWriteCommand, RegistrationWrite>
        {
            private readonly IMediator _mediator;
            private readonly IRegistrationWriteDbContext _context;
            public CreateRegistrationWriteCommandHandler(IRegistrationWriteDbContext context, IMediator mediator)
            {
                _mediator = mediator;
                _context = context;
            }
            public async Task<RegistrationWrite> Handle(CreateRegistrationWriteCommand command, CancellationToken cancellationToken)
            {
                var model = (await _mediator.Send(new GetRegistrationWriteTypeByIdQuery { Id = command.RegistrationWriteType }));

                var RegistrationWrite = new RegistrationWrite();

                RegistrationWrite.RegistrationWriteType = model;
                RegistrationWrite.Status = command.Status;
                RegistrationWrite.Data = DateTime.Now;

                _context.RegistrationWrite.Add(RegistrationWrite);
                await _context.SaveChangesAsync();
                return RegistrationWrite;
            }
        }
    }
}
