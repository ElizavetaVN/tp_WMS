using Application.Features.InternalFeatures.Commands;
using Application.Features.InternalOperationFeatures.Queries;
using Application.Features.OrderStatusFeatures.Queries;
using Application.Features.OrderTypeFeatures.Queries;
using Application.Features.PartnerFeatures.Queries;
using Application.Features.ProductFeatures.Queries;
using Application.Features.WarehouseFeatures.Queries;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.OrderFeatures.Commands
{
    public class CreateOrderCommand : IRequest<Orders>
    {
        public int OrderType { get; set; }
        public DateTime Data { get; set; }
        public Partners Partners { get; set; }
        public int Partner { get; set; }
        public int Warehouses { get; set; }
        public string Employee { get; set; }
        public int Products { get; set; }
        public int Quantity { get; set; }
        public Units Units { get; set; }
        public string Comment { get; set; }
        public int OrderStatus { get; set; }

        public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Orders>
        {
            private readonly IMediator _mediator;
            private readonly IOrderDbContext _context;
            public CreateOrderCommandHandler(IOrderDbContext context, IMediator mediator)
            {
                _mediator = mediator;
                _context = context;
            }
            public async Task<Orders> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
            {
                var model2 = (await _mediator.Send(new GetOrderTypeByIdQuery { Id = command.OrderType }));

                var Order = new Orders();
                

                Order.OrderType = model2;
                Order.Data = DateTime.Now;
                Order.Warehouses = (await _mediator.Send(new GetWarehouseByIdQuery { Id = 1 }));
                Order.OrderStatus= (await _mediator.Send(new GetOrderStatusByIdQuery { Id = 1 }));
                Order.Products = (await _mediator.Send(new GetProductByIdQuery { Id = 1 }));
                Order.Partners = (await _mediator.Send(new GetPartnerByIdQuery { Id = 1 }));

                _context.Orders.Add(Order);
                await _context.SaveChangesAsync();

                //var model = await _mediator.Send(new CreateInternalCommand ());

                return Order;
            }
        }
    }
}
