using Application.Features.OrderFeatures.Queries;
using Application.Features.RealizationTypeFeatures.Queries;
using Application.Features.WarehouseFeatures.Queries;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.RealizationFeatures.Commands
{
    public class CreateRealizationCommand : IRequest<Realization>
    {
        public int RealizationType { get; set; }
        public DateTime Data { get; set; }

        public class CreateRealizationCommandHandler : IRequestHandler<CreateRealizationCommand, Realization>
        {
            private readonly IMediator _mediator;
            private readonly IRealizationDbContext _context;
            public CreateRealizationCommandHandler(IRealizationDbContext context, IMediator mediator)
            {
                _mediator = mediator;
                _context = context;
            }
            public async Task<Realization> Handle(CreateRealizationCommand command, CancellationToken cancellationToken)
            {
                var model = (await _mediator.Send(new GetRealizationTypeByIdQuery { Id = command.RealizationType }));
                var Realization = new Realization();
                Realization.RealizationType = model;
                Realization.Data = DateTime.Now;
                Realization.Order = (await _mediator.Send(new GetOrderByIdQuery { Id = 1 }));
                Realization.Warehouses = (await _mediator.Send(new GetWarehouseByIdQuery { Id = 1 }));
                _context.Realization.Add(Realization);
                await _context.SaveChangesAsync();
                return Realization;
            }
        }
    }
}
