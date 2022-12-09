using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.OrderTypeFeatures.Queries
{
    public class GetOrderTypeByIdQuery : IRequest<OrderType>
    {
        public int Id { get; set; }
        public class GetOrderTypeByIdQueryHandler : IRequestHandler<GetOrderTypeByIdQuery, OrderType>
        {
            private readonly IOrderTypeDbContext _context;
            public GetOrderTypeByIdQueryHandler(IOrderTypeDbContext context)
            {
                _context = context;
            }
            public async Task<OrderType> Handle(GetOrderTypeByIdQuery query, CancellationToken cancellationToken)
            {
                var OrderType = _context.OrderType.Where(a => a.Id == query.Id).FirstOrDefault();
                if (OrderType == null) return null;
                return OrderType;
            }
        }
    }
}
