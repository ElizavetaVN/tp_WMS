using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.InventoryFeatures.Queries
{
    public class GetInventoryByIdQuery : IRequest<Inventory>
    {
        public int Id { get; set; }
        public class GetInventoryByIdQueryHandler : IRequestHandler<GetInventoryByIdQuery, Inventory>
        {
            private readonly IInventoryDbContext _context;
            public GetInventoryByIdQueryHandler(IInventoryDbContext context)
            {
                _context = context;
            }
            public async Task<Inventory> Handle(GetInventoryByIdQuery query, CancellationToken cancellationToken)
            {
                var Inventory = _context.Inventory.Where(a => a.Id == query.Id).FirstOrDefault();
                if (Inventory == null) return null;
                return Inventory;
            }
        }
    }
}
