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
                var Moving = await _context.Moving.ToListAsync();
                if (Moving == null)
                {
                    return null;
                }
                return Moving.AsReadOnly();
            }
        }
    }
}
