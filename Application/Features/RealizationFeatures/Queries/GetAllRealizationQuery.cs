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
                var Realization = await _context.Realization.ToListAsync();
                if (Realization == null)
                {
                    return null;
                }
                return Realization.AsReadOnly();
            }
        }
    }
}
