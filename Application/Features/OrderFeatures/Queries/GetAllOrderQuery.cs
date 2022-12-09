using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.OrderFeatures.Queries
{
    public class GetAllOrderQuery : IRequest<IEnumerable<Orders>>
    {

        public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQuery, IEnumerable<Orders>>
        {
            private readonly IOrderDbContext _context;
            public GetAllOrderQueryHandler(IOrderDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Orders>> Handle(GetAllOrderQuery query, CancellationToken cancellationToken)
            {
                var Order = await _context.Orders.ToListAsync();
                if (Order == null)
                {
                    return null;
                }
                return Order.AsReadOnly();
            }
        }
    }
}
