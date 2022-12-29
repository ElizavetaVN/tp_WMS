using Application.Features.InternalFeatures.Queries;
using Application.Features.InventoryFeatures.Queries;
using Application.Features.ProductFeatures.Queries;
using Application.Features.RegistrationWriteFeatures.Queries;
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

namespace Application.Features.RegistrationWriteFeatures.Commands
{
    public class UpdateRegistrationWriteCommand : IRequest<RegistrationWrite>
    {
        public int Id { get; set; }
        public int RegistrationWriteType { get; set; }
        public int Inventory { get; set; }
        public int Warehouses { get; set; }
        public int Products { get; set; }
        public string Quantity { get; set; }
        public int Units { get; set; }
        public DateTime Data { get; set; }
        public string Employee { get; set; }

        public class UpdateRegistrationWriteCommandHandler : IRequestHandler<UpdateRegistrationWriteCommand, RegistrationWrite>
        {
            private readonly IMediator _mediator;
            private readonly IRegistrationWriteDbContext _context;
            public UpdateRegistrationWriteCommandHandler(IRegistrationWriteDbContext context, IMediator mediator)
            {
                _mediator = mediator;
                _context = context;
            }
            public async Task<RegistrationWrite> Handle(UpdateRegistrationWriteCommand command, CancellationToken cancellationToken)
            {
                var RegistrationWrite = _context.RegistrationWrite.Where(a => a.Id == command.Id).FirstOrDefault();
                var model5 = (await _mediator.Send(new GetRegistrationWriteByIdQuery { Id = command.Id }));
                if (RegistrationWrite == null)
                {
                    return default;
                }
                else
                {
                    var model1 = (await _mediator.Send(new GetProductByIdQuery { Id = command.Products }));
                    var model2 = (await _mediator.Send(new GetInventoryByIdQuery { Id = command.Inventory }));
                    var model3 = (await _mediator.Send(new GetWarehouseByIdQuery { Id = command.Warehouses }));

                    RegistrationWrite.Inventory = model2;
                    RegistrationWrite.Warehouses = model3;
                    RegistrationWrite.Products = model1;
                    RegistrationWrite.Quantity = command.Quantity;
                    RegistrationWrite.Units = model1.Units;
                    RegistrationWrite.Data = DateTime.Now;
                    RegistrationWrite.Employee = command.Employee;
                    if (model5.RegistrationWriteType.Id == 2)
                    {
                        var model4 = await _mediator.Send(new GetAllInternalQuery());
                        int N = 0;
                        foreach (var mod in model4)
                        {
                            if ((mod.Products == model1) && (mod.Warehouses == model3) && (mod.Operation.Id == 1))
                            {
                                N = N + Convert.ToInt32(mod.Quantity);
                            }
                            else if ((mod.Products == model1) && (mod.Warehouses == model3) && (mod.Operation.Id == 2))
                            {
                                N = N - Convert.ToInt32(mod.Quantity);
                            }
                        }
                        if (N >= Convert.ToInt32(command.Quantity))
                        {
                            await _context.SaveChangesAsync();
                            return RegistrationWrite;
                        }
                        else return default;
                    }
                    else
                    {
                        await _context.SaveChangesAsync();
                        return RegistrationWrite;
                    }
                    
                }
            }
        }
    }
}
