using Application.Features.InternalFeatures.Queries;
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

namespace Application.Features.InventoryFeatures.Commands
{
    public class UpdateInventoryCommand : IRequest<Inventory>
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int Products { get; set; }
        public string QuantityFact { get; set; }
        public string QuantityAcc { get; set; }
        public Units Units { get; set; }
        public int Warehouses { get; set; }
        public string Employee { get; set; }
        public class UpdateInventoryCommandHandler : IRequestHandler<UpdateInventoryCommand, Inventory>
        {
            private readonly IMediator _mediator;
            private readonly IInventoryDbContext _context;
            public UpdateInventoryCommandHandler(IInventoryDbContext context, IMediator mediator)
            {
                _mediator = mediator;
                _context = context;
            }
            public async Task<Inventory> Handle(UpdateInventoryCommand command, CancellationToken cancellationToken)
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
                var Inventory = _context.Inventory.Where(a => a.Id == command.Id).FirstOrDefault();

                if (Inventory == null)
                {
                    return default;
                }
                else
                {
                    Inventory.Data = DateTime.Now;
                    Inventory.Products = model2;
                    Inventory.QuantityFact = N.ToString();
                    Inventory.QuantityAcc = command.QuantityAcc;
                    Inventory.Units = model2.Units;
                    Inventory.Warehouses = model1;
                    Inventory.Employee = command.Employee;
                    model2.Status = true;
                    await _context.SaveChangesAsync();
                    return Inventory;
                }
            }
        }
    }
}
