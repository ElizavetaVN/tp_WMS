using Application.Features.ProductFeatures.Queries;
using Application.Features.WarehouseFeatures.Queries;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.MovingFeatures.Commands
{
    public class CreateMovingCommand : IRequest<Moving>
    {
        public int WarehousesFrom { get; set; }
        public int WarehousesTo { get; set; }
        public int Products { get; set; }
        public string Quantity { get; set; }
        public Units Units { get; set; }
        public DateTime Data { get; set; }
        public string Employee { get; set; }

        public class CreateMovingCommandHandler : IRequestHandler<CreateMovingCommand, Moving>
        {
            private readonly IMediator _mediator;
            private readonly IMovingDbContext _context;
            public CreateMovingCommandHandler(IMovingDbContext context, IMediator mediator)
            {
                _mediator = mediator;
                _context = context;
            }
            public async Task<Moving> Handle(CreateMovingCommand command, CancellationToken cancellationToken)
            {
                var model1 = (await _mediator.Send(new GetWarehouseByIdQuery { Id = command.WarehousesFrom }));
                var model2 = (await _mediator.Send(new GetWarehouseByIdQuery { Id = command.WarehousesTo }));
                var model3 = (await _mediator.Send(new GetProductByIdQuery { Id = command.Products }));

                var Moving = new Moving();

                Moving.WarehousesFrom = model1;
                Moving.WarehousesTo = model2;
                Moving.Products = model3;
                Moving.Quantity = command.Quantity;
                Moving.Units = model3.Units;
                Moving.Data = DateTime.Now;
                Moving.Employee = command.Employee;
                model1.Status = true;
                model2.Status = true;
                model3.Status = true;
                _context.Moving.Add(Moving);
                await _context.SaveChangesAsync();
                return Moving;
            }
        }
    }
}