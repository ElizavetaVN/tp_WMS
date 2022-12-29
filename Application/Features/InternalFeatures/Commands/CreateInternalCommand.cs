using Application.Features.InternalOperationFeatures.Queries;
using Application.Features.ProductFeatures.Queries;
using Application.Features.UnitFeatures.Queries;
using Application.Features.WarehouseFeatures.Queries;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.InternalFeatures.Commands
{
    public class CreateInternalCommand : IRequest<Internal>
    {
        public Warehouses Warehouses { get; set; }
        public Products Products { get; set; }
        public int Operation { get; set; }
        public string Quantity { get; set; }
        public DateTime Data { get; set; }

        public class CreateInternalCommandHandler : IRequestHandler<CreateInternalCommand, Internal>
        {
            private readonly IMediator _mediator;
            private readonly IInternalDbContext _context;
            public CreateInternalCommandHandler(IInternalDbContext context, IMediator mediator)
            {
                _mediator = mediator;
                _context = context;
            }
            public async Task<Internal> Handle(CreateInternalCommand command, CancellationToken cancellationToken)
            {
                //var model1 = (await _mediator.Send(new GetWarehouseByIdQuery { Id = command.Warehouses }));
                //var model2 = (await _mediator.Send(new GetProductByIdQuery { Id = command.Products }));
                var model4 = (await _mediator.Send(new GetInternalOperationByIdQuery { Id = command.Operation }));

                var Internal = new Internal();

                Internal.Warehouses = command.Warehouses;
                Internal.Products = command.Products;
                Internal.Operation = model4;
                Internal.Quantity = command.Quantity;
                Internal.Data = DateTime.Now;
                _context.Internal.Add(Internal);
                await _context.SaveChangesAsync();
                return Internal;
            }
        }
    }
}
