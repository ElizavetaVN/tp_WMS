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
    public class GetAllOrderByIdQuery : IRequest<IEnumerable<Orders>>
    {
        public int Id { get; set; }
        public class GetAllOrderByIdQueryHandler : IRequestHandler<GetAllOrderByIdQuery, IEnumerable<Orders>>
        {
            private readonly IOrderDbContext _context;
            public GetAllOrderByIdQueryHandler(IOrderDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Orders>> Handle(GetAllOrderByIdQuery query, CancellationToken cancellationToken)
            {
                var Order = await _context.Orders.Where(a => a.OrderType.Id == query.Id).ToListAsync();
                if (Order == null) return null;
                return Order.AsReadOnly();
            }
        }
    }
}
