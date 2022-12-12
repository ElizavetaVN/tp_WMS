using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.InventoryFeatures.Commands
{
    public class UpdateInventoryCommand : IRequest<int>
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public Products Products { get; set; }
        public int QuantityFact { get; set; }
        public int QuantityAcc { get; set; }
        public int Units { get; set; }
        public Warehouses Warehouses { get; set; }
        public int Deviation { get; set; }
        public string Employee { get; set; }
        public class UpdateInventoryCommandHandler : IRequestHandler<UpdateInventoryCommand, int>
        {
            private readonly IInventoryDbContext _context;
            public UpdateInventoryCommandHandler(IInventoryDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateInventoryCommand command, CancellationToken cancellationToken)
            {
                var Inventory = _context.Inventory.Where(a => a.Id == command.Id).FirstOrDefault();

                if (Inventory == null)
                {
                    return default;
                }
                else
                {
                    Inventory.Data = command.Data;
                    Inventory.Products = command.Products;
                    Inventory.QuantityFact = command.QuantityFact;
                    Inventory.QuantityAcc = command.QuantityAcc;
                    Inventory.Units = command.Units;
                    Inventory.Warehouses = command.Warehouses;
                    Inventory.Deviation = command.Deviation;
                    Inventory.Employee = command.Employee;
                    await _context.SaveChangesAsync();
                    return Inventory.Id;
                }
            }
        }
    }
}
