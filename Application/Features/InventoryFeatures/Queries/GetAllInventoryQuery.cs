using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.InventoryFeatures.Queries
{
    public class GetAllInventoryQuery : IRequest<IEnumerable<Inventory>>
    {

        public class GetAllInventoryQueryHandler : IRequestHandler<GetAllInventoryQuery, IEnumerable<Inventory>>
        {
            private readonly IInventoryDbContext _context;
            public GetAllInventoryQueryHandler(IInventoryDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Inventory>> Handle(GetAllInventoryQuery query, CancellationToken cancellationToken)
            {
                var Inventory1 = _context.Inventory.Include(p => p.Warehouses);
                var Inventory2 = Inventory1.Include(p => p.Products);
                var Inventory3 = Inventory2.Include(p => p.Units);
                var Inventory = await Inventory3.ToListAsync();
                if (Inventory == null)
                {
                    return null;
                }
                return Inventory.AsReadOnly();
            }
        }
    }
}
