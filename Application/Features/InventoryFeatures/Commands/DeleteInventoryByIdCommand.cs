using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.InventoryFeatures.Commands
{
    public class DeleteInventoryByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteInventoryByIdCommandHandler : IRequestHandler<DeleteInventoryByIdCommand, int>
        {
            private readonly IInventoryDbContext _context;
            public DeleteInventoryByIdCommandHandler(IInventoryDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteInventoryByIdCommand command, CancellationToken cancellationToken)
            {
                var Inventory = await _context.Inventory.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (Inventory == null) return default;
                _context.Inventory.Remove(Inventory);
                await _context.SaveChangesAsync();
                return Inventory.Id;
            }
        }
    }
}
