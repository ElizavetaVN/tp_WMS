using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.InternalOperationFeatures.Queries
{
    public class GetAllInternalOperationQuery : IRequest<IEnumerable<InternalOperation>>
    {

        public class GetAllInternalOperationQueryHandler : IRequestHandler<GetAllInternalOperationQuery, IEnumerable<InternalOperation>>
        {
            private readonly IInternalOperationDbContext _context;
            public GetAllInternalOperationQueryHandler(IInternalOperationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<InternalOperation>> Handle(GetAllInternalOperationQuery query, CancellationToken cancellationToken)
            {
                var InternalOperation = await _context.InternalOperation.ToListAsync();
                if (InternalOperation == null)
                {
                    return null;
                }
                return InternalOperation.AsReadOnly();
            }
        }
    }
}
