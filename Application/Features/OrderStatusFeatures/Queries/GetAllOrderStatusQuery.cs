using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.OrderStatusFeatures.Queries
{
    public class GetAllOrderStatusQuery : IRequest<IEnumerable<OrderStatus>>
    {

        public class GetAllOrderStatusQueryHandler : IRequestHandler<GetAllOrderStatusQuery, IEnumerable<OrderStatus>>
        {
            private readonly IOrderStatusDbContext _context;
            public GetAllOrderStatusQueryHandler(IOrderStatusDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<OrderStatus>> Handle(GetAllOrderStatusQuery query, CancellationToken cancellationToken)
            {
                var OrderStatus = await _context.OrderStatus.ToListAsync();
                if (OrderStatus == null)
                {
                    return null;
                }
                return OrderStatus.AsReadOnly();
            }
        }
    }
}
