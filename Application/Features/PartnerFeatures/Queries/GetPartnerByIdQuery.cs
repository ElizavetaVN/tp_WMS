using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.PartnerFeatures.Queries
{
    public class GetPartnerByIdQuery : IRequest<Partners>
    {
        public int Id { get; set; }
        public class GetPartnerByIdQueryHandler : IRequestHandler<GetPartnerByIdQuery, Partners>
        {
            private readonly IPartnerDbContext _context;
            public GetPartnerByIdQueryHandler(IPartnerDbContext context)
            {
                _context = context;
            }
            public async Task<Partners> Handle(GetPartnerByIdQuery query, CancellationToken cancellationToken)
            {
                var Partner = _context.Partners.Where(a => a.Id == query.Id).FirstOrDefault();
                if (Partner == null) return null;
                return Partner;
            }
        }
    }
}
