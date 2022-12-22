using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.MovingFeatures.Queries
{
    public class GetMovingByIdQuery : IRequest<Moving>
    {
        public int Id { get; set; }
        public class GetMovingByIdQueryHandler : IRequestHandler<GetMovingByIdQuery, Moving>
        {
            private readonly IMovingDbContext _context;
            public GetMovingByIdQueryHandler(IMovingDbContext context)
            {
                _context = context;
            }
            public async Task<Moving> Handle(GetMovingByIdQuery query, CancellationToken cancellationToken)
            {
                var Moving = _context.Moving.Where(a => a.Id == query.Id).FirstOrDefault();
                if (Moving == null) return null;
                return Moving;
            }
        }
    }
}
