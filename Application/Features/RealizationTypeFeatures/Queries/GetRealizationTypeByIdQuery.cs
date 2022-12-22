using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.RealizationTypeFeatures.Queries
{
    public class GetRealizationTypeByIdQuery : IRequest<RealizationType>
    {
        public int Id { get; set; }
        public class GetRealizationTypeByIdQueryHandler : IRequestHandler<GetRealizationTypeByIdQuery, RealizationType>
        {
            private readonly IRealizationTypeDbContext _context;
            public GetRealizationTypeByIdQueryHandler(IRealizationTypeDbContext context)
            {
                _context = context;
            }
            public async Task<RealizationType> Handle(GetRealizationTypeByIdQuery query, CancellationToken cancellationToken)
            {
                var RealizationType = _context.RealizationType.Where(a => a.Id == query.Id).FirstOrDefault();
                if (RealizationType == null) return null;
                return RealizationType;
            }
        }
    }
}
