using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.InternalStatusFeatures.Queries
{
    public class GetInternalStatusByIdQuery : IRequest<InternalStatus>
    {
        public int Id { get; set; }
        public class GetInternalStatusByIdQueryHandler : IRequestHandler<GetInternalStatusByIdQuery, InternalStatus>
        {
            private readonly IInternalStatusDbContext _context;
            public GetInternalStatusByIdQueryHandler(IInternalStatusDbContext context)
            {
                _context = context;
            }
            public async Task<InternalStatus> Handle(GetInternalStatusByIdQuery query, CancellationToken cancellationToken)
            {
                var InternalStatus = _context.InternalStatus.Where(a => a.Id == query.Id).FirstOrDefault();
                if (InternalStatus == null) return null;
                return InternalStatus;
            }
        }
    }
}
