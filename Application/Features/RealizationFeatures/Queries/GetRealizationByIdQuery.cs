using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.RealizationFeatures.Queries
{
    public class GetRealizationByIdQuery : IRequest<Realization>
    {
        public int Id { get; set; }
        public class GetRealizationByIdQueryHandler : IRequestHandler<GetRealizationByIdQuery, Realization>
        {
            private readonly IRealizationDbContext _context;
            public GetRealizationByIdQueryHandler(IRealizationDbContext context)
            {
                _context = context;
            }
            public async Task<Realization> Handle(GetRealizationByIdQuery query, CancellationToken cancellationToken)
            {
                var Realization = _context.Realization.Where(a => a.Id == query.Id).FirstOrDefault();
                if (Realization == null) return null;
                return Realization;
            }
        }
    }
}
