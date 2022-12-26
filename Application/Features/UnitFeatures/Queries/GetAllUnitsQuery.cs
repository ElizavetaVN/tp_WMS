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

namespace Application.Features.UnitFeatures.Queries
{
    public class GetAllUnitsQuery : IRequest<IEnumerable<Units>>
    {

        public class GetAllUnitsQueryHandler : IRequestHandler<GetAllUnitsQuery, IEnumerable<Units>>
        {
            private readonly IMediator _mediator;
            private readonly IUnitDbContext _context;
            public GetAllUnitsQueryHandler(IUnitDbContext context, IMediator mediator)
            {
                _mediator = mediator;
                _context = context;
            }
            public async Task<IEnumerable<Units>> Handle(GetAllUnitsQuery query, CancellationToken cancellationToken)
            {
                var unitList = await _context.Units.ToListAsync();

                var models = (await _mediator.Send(new GetAllProductQuery()));
                foreach (var unit in unitList)
                {
                    foreach (var prod in models)
                    {
                        if (unit == prod.Units && prod != null)
                        {
                            unit.Status = true;
                            await _context.SaveChangesAsync();
                            break;
                        }
                        else
                        {
                            unit.Status = false;
                            await _context.SaveChangesAsync();
                        }
                    }
                }
                if (unitList == null)
                {
                    return null;
                }
                return unitList.AsReadOnly();
            }
        }
    }
}
