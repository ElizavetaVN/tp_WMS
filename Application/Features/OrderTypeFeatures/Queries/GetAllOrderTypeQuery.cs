using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.OrderTypeFeatures.Queries
{
    public class GetAllOrderTypeQuery : IRequest<IEnumerable<OrderType>>
    {

        public class GetAllOrderTypeQueryHandler : IRequestHandler<GetAllOrderTypeQuery, IEnumerable<OrderType>>
        {
            private readonly IOrderTypeDbContext _context;
            public GetAllOrderTypeQueryHandler(IOrderTypeDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<OrderType>> Handle(GetAllOrderTypeQuery query, CancellationToken cancellationToken)
            {
                var OrderType = await _context.OrderType.ToListAsync();
                if (OrderType == null)
                {
                    return null;
                }
                return OrderType.AsReadOnly();
            }
        }
    }
}
