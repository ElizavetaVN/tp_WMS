using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.ProductFeatures.Queries;

namespace Application.Features.PartnerFeatures.Queries
{
    public class GetAllPartnerQuery : IRequest<IEnumerable<Partners>>
    {

        public class GetAllPartnerQueryHandler : IRequestHandler<GetAllPartnerQuery, IEnumerable<Partners>>
        {
            private readonly IMediator _mediator;
            private readonly IPartnerDbContext _context;
            public GetAllPartnerQueryHandler(IPartnerDbContext context, IMediator mediator)
            {
                _mediator = mediator;
                _context = context;
            }
            public async Task<IEnumerable<Partners>> Handle(GetAllPartnerQuery query, CancellationToken cancellationToken)
            {
                var PartnerList = await _context.Partners.ToListAsync();
                var models = (await _mediator.Send(new GetAllProductQuery()));
                foreach (var partner in PartnerList)
                {
                    foreach (var prod in models)
                    {
                        if (partner == prod.Provider && prod != null)
                        {
                            partner.Status = true;
                            await _context.SaveChangesAsync();
                            break;
                        }
                        else
                        {
                            partner.Status = false;
                            await _context.SaveChangesAsync();
                        }
                    }
                }
                if (PartnerList == null)
                {
                    return null;
                }
                return PartnerList.AsReadOnly();
            }
        }
    }
}
