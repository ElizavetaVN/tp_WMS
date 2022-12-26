using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.OrderFeatures.Queries
{
    public class GetOrderByIdQuery : IRequest<Orders>
    {
        public int Id { get; set; }
        public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Orders>
        {
            private readonly IOrderDbContext _context;
            public GetOrderByIdQueryHandler(IOrderDbContext context)
            {
                _context = context;
            }
            public async Task<Orders> Handle(GetOrderByIdQuery query, CancellationToken cancellationToken)
            {
                var Order1 = _context.Orders.Include(p => p.Products.Units);
                var Order2= Order1.Include(p => p.Products.Provider);
                var Order =  Order2.Where(a => a.Id == query.Id).FirstOrDefault();
                if (Order == null) return null;
                return Order;
            }
        }
    }
}
