using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.OrderFeatures.Commands
{
    public class UpdateOrderCommand : IRequest<Orders>
    {
        public int Id { get; set; }
        public OrderType OrderType { get; set; }
        public DateTime Data { get; set; }
        public Partners Partners { get; set; }
        public Warehouses Warehouses { get; set; }
        public string Employee { get; set; }
        public Products Products { get; set; }
        public int Quantity { get; set; }
        public int Units { get; set; }
        public string Comment { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Orders>
        {
            private readonly IOrderDbContext _context;
            public UpdateOrderCommandHandler(IOrderDbContext context)
            {
                _context = context;
            }
            public async Task<Orders> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
            {
                var Order = _context.Orders.Where(a => a.Id == command.Id).FirstOrDefault();

                if (Order == null)
                {
                    return default;
                }
                else
                {
                    Order.OrderType = command.OrderType;
                    Order.Data = command.Data;
                    Order.Partners = command.Partners;
                    Order.Warehouses = command.Warehouses;
                    Order.Employee = command.Employee;
                    Order.Products = command.Products;
                    Order.Quantity = command.Quantity;
                    Order.Units = command.Units;
                    Order.Comment = command.Comment;
                    Order.OrderStatus = command.OrderStatus;
                    await _context.SaveChangesAsync();
                    return Order;
                }
            }
        }
    }
}
