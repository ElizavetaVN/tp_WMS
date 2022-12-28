using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.InternalStatusFeatures.Queries
{
    public class GetAllInternalStatusQuery : IRequest<IEnumerable<InternalStatus>>
    {

        public class GetAllInternalStatusQueryHandler : IRequestHandler<GetAllInternalStatusQuery, IEnumerable<InternalStatus>>
        {
            private readonly IInternalStatusDbContext _context;
            public GetAllInternalStatusQueryHandler(IInternalStatusDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<InternalStatus>> Handle(GetAllInternalStatusQuery query, CancellationToken cancellationToken)
            {
                var InternalStatus = await _context.InternalStatus.ToListAsync();
                if (InternalStatus == null)
                {
                    return null;
                }
                return InternalStatus.AsReadOnly();
            }
        }
    }
}
