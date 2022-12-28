using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.RealizationFeatures.Queries
{
    public class GetAllRealizationQuery : IRequest<IEnumerable<Realization>>
    {

        public class GetAllRealizationQueryHandler : IRequestHandler<GetAllRealizationQuery, IEnumerable<Realization>>
        {
            private readonly IRealizationDbContext _context;
            public GetAllRealizationQueryHandler(IRealizationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Realization>> Handle(GetAllRealizationQuery query, CancellationToken cancellationToken)
            {
                var Realization1 = _context.Realization.Include(p => p.RealizationType);
                var Realization2 = Realization1.Include(p => p.Order);
                var Realization3 = Realization2.Include(p => p.Partners);
                var Realization4 = Realization3.Include(p => p.Warehouses);
                var Realization5 = Realization4.Include(p => p.Products);
                var Realization6 = Realization5.Include(p => p.Units);
                var Realization = await Realization6.ToListAsync();
                if (Realization == null)
                {
                    return null;
                }
                return Realization.AsReadOnly();
            }
        }
    }
}
