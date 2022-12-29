using Application.Features.InternalFeatures.Queries;
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

namespace Application.Features.InventoryFeatures.Commands
{
    public class CreateInventoryCommand : IRequest<Inventory>
    {
        public DateTime Data { get; set; }
        public int Products { get; set; }
        public string QuantityFact { get; set; }
        public string QuantityAcc { get; set; }
        public Units Units { get; set; }
        public int Warehouses { get; set; }
        public string Employee { get; set; }

        public class CreateInventoryCommandHandler : IRequestHandler<CreateInventoryCommand, Inventory>
        {
            private readonly IMediator _mediator;
            private readonly IInventoryDbContext _context;
            public CreateInventoryCommandHandler(IInventoryDbContext context, IMediator mediator)
            {
                _mediator = mediator;
                _context = context;
            }
            public async Task<Inventory> Handle(CreateInventoryCommand command, CancellationToken cancellationToken)
            {
                var model1 = (await _mediator.Send(new GetWarehouseByIdQuery { Id = command.Warehouses }));
                var model2 = (await _mediator.Send(new GetProductByIdQuery { Id = command.Products }));

                var model3 = await _mediator.Send(new GetAllInternalQuery());
                int N = 0;
                foreach (var mod in model3)
                {
                    if ((mod.Warehouses == model1) && (mod.Products == model2))
                    {
                        N = N + Convert.ToInt32(mod.Quantity);
                    }
                }
                var Inventory = new Inventory();
                Inventory.Data = DateTime.Now;
                Inventory.Products = model2;
                Inventory.QuantityFact = N.ToString();
                Inventory.QuantityAcc = command.QuantityAcc;
                Inventory.Units = model2.Units;
                Inventory.Warehouses = model1;
                Inventory.Employee = command.Employee;
                model2.Status = true;
                _context.Inventory.Add(Inventory);
                await _context.SaveChangesAsync();
                return Inventory;
            }
        }
    }
}
