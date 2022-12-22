using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.RealizationTypeFeatures.Queries
{
    public class GetAllRealizationTypeQuery : IRequest<IEnumerable<RealizationType>>
    {

        public class GetAllRealizationTypeQueryHandler : IRequestHandler<GetAllRealizationTypeQuery, IEnumerable<RealizationType>>
        {
            private readonly IRealizationTypeDbContext _context;
            public GetAllRealizationTypeQueryHandler(IRealizationTypeDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<RealizationType>> Handle(GetAllRealizationTypeQuery query, CancellationToken cancellationToken)
            {
                var RealizationType = await _context.RealizationType.ToListAsync();
                if (RealizationType == null)
                {
                    return null;
                }
                return RealizationType.AsReadOnly();
            }
        }
    }
}
