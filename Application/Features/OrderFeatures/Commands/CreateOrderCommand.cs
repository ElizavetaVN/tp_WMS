using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.OrderFeatures.Commands
{
    public class CreateOrderCommand : IRequest<int>
    {
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
        public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
        {
            private readonly IOrderDbContext _context;
            public CreateOrderCommandHandler(IOrderDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
            {
                var Order = new Orders();
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
                _context.Orders.Add(Order);
                await _context.SaveChangesAsync();
                return Order.Id;
            }
        }
    }
}
