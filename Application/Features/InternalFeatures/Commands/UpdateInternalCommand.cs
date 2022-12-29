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

namespace Application.Features.InternalFeatures.Commands
{
    public class UpdateInternalCommand : IRequest<Internal>
    {
        public int Id { get; set; }
        public int Warehouses { get; set; }
        public int Products { get; set; }
        public int Status { get; set; }
        public int Operation { get; set; }
        public int Number { get; set; }
        public string Quantity { get; set; }
        public DateTime Data { get; set; }
        public class UpdateInternalCommandHandler : IRequestHandler<UpdateInternalCommand, Internal>
        {
            private readonly IMediator _mediator;
            private readonly IInternalDbContext _context;
            public UpdateInternalCommandHandler(IInternalDbContext context, IMediator mediator)
            {
                _mediator = mediator;
                _context = context;
            }
            public async Task<Internal> Handle(UpdateInternalCommand command, CancellationToken cancellationToken)
            {
                var Internal = _context.Internal.Where(a => a.Id == command.Id).FirstOrDefault();
                if (Internal == null)
                {
                    return default;
                }
                else
                {
                        await _context.SaveChangesAsync();
                        return Internal;
                }
            }
        }
    }
}
