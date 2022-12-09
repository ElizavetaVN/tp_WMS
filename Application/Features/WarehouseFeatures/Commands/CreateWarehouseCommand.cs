using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.WarehouseFeatures.Commands
{
    public class CreateOrderCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public class CreateWarehouseCommandHandler : IRequestHandler<CreateOrderCommand, int>
        {
            private readonly IWarehouseDbContext _context;
            public CreateWarehouseCommandHandler(IWarehouseDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
            {
                var warehouse = new Warehouses();
                warehouse.FullName = command.FullName;
                warehouse.Name = command.Name;
                _context.Warehouses.Add(warehouse);
                await _context.SaveChangesAsync();
                return warehouse.Id;
            }
        }
    }
}
