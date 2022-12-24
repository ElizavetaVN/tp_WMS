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
        public Warehouses WarehousesFrom { get; set; }
        public Warehouses WarehousesTo { get; set; }
        public Products Products { get; set; }
        public int Quantity { get; set; }
        public int Units { get; set; }
        public DateTime Data { get; set; }
        public string Employee { get; set; }

        public class CreateMovingCommandHandler : IRequestHandler<CreateMovingCommand, Moving>
        {
            private readonly IMovingDbContext _context;
            public CreateMovingCommandHandler(IMovingDbContext context)
            {
                _context = context;
            }
            public async Task<Moving> Handle(CreateMovingCommand command, CancellationToken cancellationToken)
            {
                var Moving = new Moving();
                Moving.WarehousesFrom = command.WarehousesFrom;
                Moving.WarehousesTo = command.WarehousesTo;
                Moving.Products = command.Products;
                Moving.Quantity = command.Quantity;
                Moving.Units = command.Units;
                Moving.Data = command.Data;
                Moving.Employee = command.Employee;
                _context.Moving.Add(Moving);
                await _context.SaveChangesAsync();
                return Moving;
            }
        }
    }
}