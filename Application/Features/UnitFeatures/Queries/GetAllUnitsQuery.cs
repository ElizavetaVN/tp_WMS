using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UnitFeatures.Queries
{
    public class GetAllUnitsQuery : IRequest<IEnumerable<Units>>
    {

        public class GetAllUnitsQueryHandler : IRequestHandler<GetAllUnitsQuery, IEnumerable<Units>>
        {
            private readonly IUnitDbContext _context;
            public GetAllUnitsQueryHandler(IUnitDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Units>> Handle(GetAllUnitsQuery query, CancellationToken cancellationToken)
            {
                var productList = await _context.Units.ToListAsync();
                if (productList == null)
                {
                    return null;
                }
                return productList.AsReadOnly();
            }
        }
    }
}
