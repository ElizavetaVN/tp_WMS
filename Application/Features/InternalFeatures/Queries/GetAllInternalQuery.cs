using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.InternalFeatures.Queries
{
    public class GetAllInternalQuery : IRequest<IEnumerable<Internal>>
    {
        public class GetAllInternalQueryHandler : IRequestHandler<GetAllInternalQuery, IEnumerable<Internal>>
        {
            private readonly IInternalDbContext _context;
            public GetAllInternalQueryHandler(IInternalDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Internal>> Handle(GetAllInternalQuery query, CancellationToken cancellationToken)
            {
                var Internal1 = _context.Internal.Include(p => p.Warehouses);
                var Internal2 = Internal1.Include(p => p.Products);
                var Internal3 = Internal2.Include(p => p.Operation);
                var Internal = await Internal3.ToListAsync();

                if (Internal == null)
                {
                    return null;
                }
                return Internal;
            }
        }
    }
}
