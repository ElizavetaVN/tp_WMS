using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.OrderStatusFeatures.Queries
{
    public class GetOrderStatusByIdQuery : IRequest<OrderStatus>
    {
        public int Id { get; set; }
        public class GetOrderStatusByIdQueryHandler : IRequestHandler<GetOrderStatusByIdQuery, OrderStatus>
        {
            private readonly IOrderStatusDbContext _context;
            public GetOrderStatusByIdQueryHandler(IOrderStatusDbContext context)
            {
                _context = context;
            }
            public async Task<OrderStatus> Handle(GetOrderStatusByIdQuery query, CancellationToken cancellationToken)
            {
                var OrderStatus = _context.OrderStatus.Where(a => a.Id == query.Id).FirstOrDefault();
                if (OrderStatus == null) return null;
                return OrderStatus;
            }
        }
    }
}
