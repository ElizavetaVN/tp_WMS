using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.InternalFeatures.Queries
{
    public class GetInternalByIdQuery : IRequest<Internal>
    {
        public int Id { get; set; }
        public class GetInternalByIdQueryHandler : IRequestHandler<GetInternalByIdQuery, Internal>
        {
            private readonly IInternalDbContext _context;
            public GetInternalByIdQueryHandler(IInternalDbContext context)
            {
                _context = context;
            }
            public async Task<Internal> Handle(GetInternalByIdQuery query, CancellationToken cancellationToken)
            {
                var Internal = _context.Internal.Where(a => a.Id == query.Id).FirstOrDefault();
                if (Internal == null) return null;
                return Internal;
            }
        }
    }
}
