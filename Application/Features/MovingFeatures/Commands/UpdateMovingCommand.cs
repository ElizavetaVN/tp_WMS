using Application.Features.ProductFeatures.Queries;
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

namespace Application.Features.MovingFeatures.Commands
{
    public class UpdateMovingCommand : IRequest<Moving>
    {
        public int Id { get; set; }
        public int WarehousesFrom { get; set; }
        public int WarehousesTo { get; set; }
        public int Products { get; set; }
        public int Quantity { get; set; }
        public Units Units { get; set; }
        public DateTime Data { get; set; }
        public string Employee { get; set; }

        public class UpdateMovingCommandHandler : IRequestHandler<UpdateMovingCommand, Moving>
        {
            private readonly IMediator _mediator;
            private readonly IMovingDbContext _context;
            public UpdateMovingCommandHandler(IMovingDbContext context, IMediator mediator)
            {
                _mediator = mediator;
                _context = context;
            }
            public async Task<Moving> Handle(UpdateMovingCommand command, CancellationToken cancellationToken)
            {
                var model1 = (await _mediator.Send(new GetWarehouseByIdQuery { Id = command.WarehousesFrom }));
                var model2 = (await _mediator.Send(new GetWarehouseByIdQuery { Id = command.WarehousesTo }));
                var model3 = (await _mediator.Send(new GetProductByIdQuery { Id = command.Products }));

                var Moving = _context.Moving.Where(a => a.Id == command.Id).FirstOrDefault();

                if (Moving == null)
                {
                    return default;
                }
                else
                {
                    if (model1 != null && model2 != null && model3 != null)
                    {
                        Moving.WarehousesFrom = model1;
                        Moving.WarehousesTo = model2;
                        Moving.Products = model3;
                        Moving.Quantity = Moving.Quantity;
                        Moving.Units = model3.Units;
                        Moving.Data = DateTime.Now;
                        Moving.Employee = command.Employee;
                        model1.Status = true;
                        model2.Status = true;
                        model3.Status = true;
                        await _context.SaveChangesAsync();
                        return Moving;
                    }
                    else
                    {
                        return default;
                    }
                }
            }
        }
    }
}
