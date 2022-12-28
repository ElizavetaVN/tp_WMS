using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.InternalOperationFeatures.Queries
{
    public class GetInternalOperationByIdQuery : IRequest<InternalOperation>
    {
        public int Id { get; set; }
        public class GetInternalOperationByIdQueryHandler : IRequestHandler<GetInternalOperationByIdQuery, InternalOperation>
        {
            private readonly IInternalOperationDbContext _context;
            public GetInternalOperationByIdQueryHandler(IInternalOperationDbContext context)
            {
                _context = context;
            }
            public async Task<InternalOperation> Handle(GetInternalOperationByIdQuery query, CancellationToken cancellationToken)
            {
                var InternalOperation = _context.InternalOperation.Where(a => a.Id == query.Id).FirstOrDefault();
                if (InternalOperation == null) return null;
                return InternalOperation;
            }
        }
    }
}
