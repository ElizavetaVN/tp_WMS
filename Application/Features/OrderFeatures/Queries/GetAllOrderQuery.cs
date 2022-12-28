using Application.Features.ProductFeatures.Queries;
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
            private readonly IMediator _mediator;
            private readonly IOrderDbContext _context;
            public GetAllOrderQueryHandler(IOrderDbContext context, IMediator mediator)
            {
                _mediator = mediator;
                _context = context;
            }
            public async Task<IEnumerable<Orders>> Handle(GetAllOrderQuery query, CancellationToken cancellationToken)
            {
                var Order1 =  _context.Orders.Include(p => p.OrderType);
                var Order2 = Order1.Include(p => p.OrderStatus);
                var Order3 = Order2.Include(p => p.Units);
                var Order4 = Order3.Include(p => p.Products);
                var Order5 = Order4.Include(p => p.Warehouses);
                var Order6 = Order5.Include(p => p.Partners);
                var Order = await Order6.ToListAsync();

                foreach (var unit in Order)
                {
                    if (unit.OrderType.Id == 2 && unit.Products != null && unit.Products.Provider != null)
                    {
                        unit.Partners = unit.Products.Provider;
                        await _context.SaveChangesAsync();
                    }
                }
                if (Order == null)
                {
                    return null;
                }
                return Order.AsReadOnly();
            }
        }
    }
}
