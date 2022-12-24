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
        public Warehouses WarehousesFrom { get; set; }
        public Warehouses WarehousesTo { get; set; }
        public Products Products { get; set; }
        public int Quantity { get; set; }
        public int Units { get; set; }
        public DateTime Data { get; set; }
        public string Employee { get; set; }

        public class UpdateMovingCommandHandler : IRequestHandler<UpdateMovingCommand, Moving>
        {
            private readonly IMovingDbContext _context;
            public UpdateMovingCommandHandler(IMovingDbContext context)
            {
                _context = context;
            }
            public async Task<Moving> Handle(UpdateMovingCommand command, CancellationToken cancellationToken)
            {
                var Moving = _context.Moving.Where(a => a.Id == command.Id).FirstOrDefault();

                if (Moving == null)
                {
                    return default;
                }
                else
                {
                    Moving.WarehousesFrom = Moving.WarehousesFrom;
                    Moving.WarehousesTo = Moving.WarehousesTo;
                    Moving.Products = Moving.Products;
                    Moving.Quantity = Moving.Quantity;
                    Moving.Units = Moving.Units;
                    Moving.Data = Moving.Data;
                    Moving.Employee = Moving.Employee;
                    await _context.SaveChangesAsync();
                    return Moving;
                }
            }
        }
    }
}
