using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.InventoryFeatures.Commands
{
    public class CreateInventoryCommand : IRequest<Inventory>
    {
        public DateTime Data { get; set; }
        public Products Products { get; set; }
        public int QuantityFact { get; set; }
        public int QuantityAcc { get; set; }
        public int Units { get; set; }
        public Warehouses Warehouses { get; set; }
        public int Deviation { get; set; }
        public string Employee { get; set; }

        public class CreateInventoryCommandHandler : IRequestHandler<CreateInventoryCommand, Inventory>
        {
            private readonly IInventoryDbContext _context;
            public CreateInventoryCommandHandler(IInventoryDbContext context)
            {
                _context = context;
            }
            public async Task<Inventory> Handle(CreateInventoryCommand command, CancellationToken cancellationToken)
            {
                var Inventory = new Inventory();
                Inventory.Data = command.Data;
                Inventory.Products = command.Products;
                Inventory.QuantityFact = command.QuantityFact;
                Inventory.QuantityAcc = command.QuantityAcc;
                Inventory.Units = command.Units;
                Inventory.Warehouses = command.Warehouses;
                Inventory.Deviation = command.Deviation;
                Inventory.Employee = command.Employee;
                _context.Inventory.Add(Inventory);
                await _context.SaveChangesAsync();
                return Inventory;
            }
        }
    }
}
