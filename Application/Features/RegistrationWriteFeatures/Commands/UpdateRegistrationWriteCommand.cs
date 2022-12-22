using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.RegistrationWriteFeatures.Commands
{
    public class UpdateRegistrationWriteCommand : IRequest<RegistrationWrite>
    {
        public int Id { get; set; }
        public RegistrationWriteType RegistrationWriteType { get; set; }
        public Inventory Inventory { get; set; }
        public Warehouses Warehouses { get; set; }
        public Products Products { get; set; }
        public int Quantity { get; set; }
        public int Units { get; set; }
        public DateTime Data { get; set; }
        public string Employee { get; set; }

        public class UpdateRegistrationWriteCommandHandler : IRequestHandler<UpdateRegistrationWriteCommand, RegistrationWrite>
        {
            private readonly IRegistrationWriteDbContext _context;
            public UpdateRegistrationWriteCommandHandler(IRegistrationWriteDbContext context)
            {
                _context = context;
            }
            public async Task<RegistrationWrite> Handle(UpdateRegistrationWriteCommand command, CancellationToken cancellationToken)
            {
                var RegistrationWrite = _context.RegistrationWrite.Where(a => a.Id == command.Id).FirstOrDefault();

                if (RegistrationWrite == null)
                {
                    return default;
                }
                else
                {
                    RegistrationWrite.RegistrationWriteType = command.RegistrationWriteType;
                    RegistrationWrite.Inventory = command.Inventory;
                    RegistrationWrite.Warehouses = command.Warehouses;
                    RegistrationWrite.Products = command.Products;
                    RegistrationWrite.Quantity = command.Quantity;
                    RegistrationWrite.Units = command.Units;
                    RegistrationWrite.Data = command.Data;
                    RegistrationWrite.Employee = command.Employee;

                    await _context.SaveChangesAsync();
                    return RegistrationWrite;
                }
            }
        }
    }
}
