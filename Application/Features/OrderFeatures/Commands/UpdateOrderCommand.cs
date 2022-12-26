using Application.Features.OrderFeatures.Queries;
using Application.Features.OrderStatusFeatures.Queries;
using Application.Features.OrderTypeFeatures.Queries;
using Application.Features.PartnerFeatures.Queries;
using Application.Features.ProductFeatures.Queries;
using Application.Features.UnitFeatures.Queries;
using Application.Features.WarehouseFeatures.Queries;
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
        public DateTime Data { get; set; }
        public int Partners { get; set; }
        public int Warehouses { get; set; }
        public string Employee { get; set; }
        public int Products { get; set; }
        public int Quantity { get; set; }
        public int Units { get; set; }
        public string Comment { get; set; }
        public int OrderStatus { get; set; }
        public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Orders>
        {
            private readonly IMediator _mediator;
            private readonly IOrderDbContext _context;
            public UpdateOrderCommandHandler(IOrderDbContext context, IMediator mediator)
            {
                _mediator = mediator;
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
                    var model1 = (await _mediator.Send(new GetProductByIdQuery { Id = command.Products }));
                    var model3 = (await _mediator.Send(new GetOrderStatusByIdQuery { Id = command.OrderStatus }));
                    var model4 = (await _mediator.Send(new GetWarehouseByIdQuery { Id = command.Warehouses }));
                    var model5 = (await _mediator.Send(new GetPartnerByIdQuery { Id = command.Partners }));
                    Order.Data = DateTime.Now;
                    
                    Order.Partners = model5;
                    
                    Order.Warehouses = model4;
                    Order.Employee = command.Employee;
                    Order.Products = model1;
                    Order.Quantity = command.Quantity;
                    Order.Units = model1.Units;
                    Order.Comment = command.Comment;
                    Order.OrderStatus = model3;
                    model1.Status = true;
                    await _context.SaveChangesAsync();
                    
                    return Order;
                }
            }
        }
    }
}
