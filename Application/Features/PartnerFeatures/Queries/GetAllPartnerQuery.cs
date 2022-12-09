using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.PartnerFeatures.Queries
{
    public class GetAllPartnerQuery : IRequest<IEnumerable<Partners>>
    {

        public class GetAllPartnerQueryHandler : IRequestHandler<GetAllPartnerQuery, IEnumerable<Partners>>
        {
            private readonly IPartnerDbContext _context;
            public GetAllPartnerQueryHandler(IPartnerDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Partners>> Handle(GetAllPartnerQuery query, CancellationToken cancellationToken)
            {
                var PartnerList = await _context.Partners.ToListAsync();
                if (PartnerList == null)
                {
                    return null;
                }
                return PartnerList.AsReadOnly();
            }
        }
    }
}
