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

namespace Application.Features.OrderFeatures.Commands
{
    public class DeleteOrderByIdCommand : IRequest<Orders>
    {
        public int Id { get; set; }
        public class DeleteOrderByIdCommandHandler : IRequestHandler<DeleteOrderByIdCommand, Orders>
        {
            private readonly IOrderDbContext _context;
            public DeleteOrderByIdCommandHandler(IOrderDbContext context)
            {
                _context = context;
            }
            public async Task<Orders> Handle(DeleteOrderByIdCommand command, CancellationToken cancellationToken)
            {
                var Order = await _context.Orders.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (Order == null) return default;
                _context.Orders.Remove(Order);
                await _context.SaveChangesAsync();
                return Order;
            }
        }
    }
}
