using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.MovingFeatures.Queries
{
    public class GetAllMovingQuery : IRequest<IEnumerable<Moving>>
    {

        public class GetAllMovingQueryHandler : IRequestHandler<GetAllMovingQuery, IEnumerable<Moving>>
        {
            private readonly IMovingDbContext _context;
            public GetAllMovingQueryHandler(IMovingDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Moving>> Handle(GetAllMovingQuery query, CancellationToken cancellationToken)
            {
                var Moving1 = _context.Moving.Include(p => p.WarehousesFrom);
                var Moving2 = Moving1.Include(p => p.WarehousesTo);
                var Moving3 = Moving2.Include(p => p.Products);
                var Moving4 = Moving3.Include(p => p.Units);
                var Moving = await Moving4.ToListAsync();
                if (Moving == null)
                {
                    return null;
                }
                return Moving.AsReadOnly();
            }
        }
    }
}
