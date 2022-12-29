using Application.Features.InternalFeatures.Queries;
using Application.Features.OrderFeatures.Queries;
using Application.Features.RealizationFeatures.Queries;
using Application.Features.WarehouseFeatures.Queries;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.RealizationFeatures.Commands
{
    public class UpdateRealizationCommand : IRequest<Realization>
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int Order { get; set; }
        public int Partners { get; set; }
        public int Warehouses { get; set; }
        public int Products { get; set; }
        public string Quantity { get; set; }
        public int Units { get; set; }
        public string Employee { get; set; }
        public string Comment { get; set; }
        public class UpdateRealizationCommandHandler : IRequestHandler<UpdateRealizationCommand, Realization>
        {
            private readonly IMediator _mediator;
            private readonly IRealizationDbContext _context;
            public UpdateRealizationCommandHandler(IRealizationDbContext context, IMediator mediator)
            {
                _mediator = mediator;
                _context = context;
            }
            public async Task<Realization> Handle(UpdateRealizationCommand command, CancellationToken cancellationToken)
            {

                var model = (await _mediator.Send(new GetOrderByIdQuery { Id = command.Order }));
                var model2 = (await _mediator.Send(new GetRealizationByIdQuery { Id = command.Id }));
                var model1 = (await _mediator.Send(new GetWarehouseByIdQuery { Id = command.Warehouses }));
                var Realization = _context.Realization.Where(a => a.Id == command.Id).FirstOrDefault();

                if (Realization == null)
                {
                    return default;
                }
                else
                {
                    Realization.Data = DateTime.Now;
                    Realization.Order = model;
                    Realization.Partners = model.Partners;
                    Realization.Warehouses = model1;
                    Realization.Products = model.Products;
                    Realization.Quantity = model.Quantity;
                    Realization.Units = model.Units;
                    Realization.Employee = command.Employee;
                    Realization.Comment = command.Comment;
                    if (model2.RealizationType.Id == 1)
                    {
                        var model4 = await _mediator.Send(new GetAllInternalQuery());
                        int N = 0;
                        foreach (var mod in model4)
                        {
                            if ((mod.Products == model.Products) && (mod.Warehouses == model1) && (mod.Operation.Id == 1))
                            {
                                N = N + Convert.ToInt32(mod.Quantity);
                            }
                            else if ((mod.Products == model.Products) && (mod.Warehouses == model1) && (mod.Operation.Id == 2))
                            {
                                N = N - Convert.ToInt32(mod.Quantity);
                            }
                        }
                        if (N >= Convert.ToInt32(model.Quantity))
                        {
                            await _context.SaveChangesAsync();
                            return Realization;
                        }
                        else return default;
                    }
                    else
                    {
                        await _context.SaveChangesAsync();
                        return Realization;
                    }
                }
            }
        }
    }
}
