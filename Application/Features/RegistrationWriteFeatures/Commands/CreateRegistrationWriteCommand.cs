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
        public RegistrationWriteType RegistrationWriteType { get; set; }
        public Inventory Inventory { get; set; }
        public Warehouses Warehouses { get; set; }
        public Products Products { get; set; }
        public int Quantity { get; set; }
        public int Units { get; set; }
        public DateTime Data { get; set; }
        public string Employee { get; set; }

        public class CreateRegistrationWriteCommandHandler : IRequestHandler<CreateRegistrationWriteCommand, RegistrationWrite>
        {
            private readonly IRegistrationWriteDbContext _context;
            public CreateRegistrationWriteCommandHandler(IRegistrationWriteDbContext context)
            {
                _context = context;
            }
            public async Task<RegistrationWrite> Handle(CreateRegistrationWriteCommand command, CancellationToken cancellationToken)
            {
                var RegistrationWrite = new RegistrationWrite();
                RegistrationWrite.RegistrationWriteType = command.RegistrationWriteType;
                RegistrationWrite.Inventory = command.Inventory;
                RegistrationWrite.Warehouses = command.Warehouses;
                RegistrationWrite.Products = command.Products;
                RegistrationWrite.Quantity = command.Quantity;
                RegistrationWrite.Units = command.Units;
                RegistrationWrite.Data = command.Data;
                RegistrationWrite.Employee = command.Employee;

                _context.RegistrationWrite.Add(RegistrationWrite);
                await _context.SaveChangesAsync();
                return RegistrationWrite;
            }
        }
    }
}
