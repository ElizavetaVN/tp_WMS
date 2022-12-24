using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.WarehouseFeatures.Commands
{
    public class DeleteWarehouseByIdCommand : IRequest<Warehouses>
    {
        public int Id { get; set; }
        public class DeleteWarehouseByIdCommandHandler : IRequestHandler<DeleteWarehouseByIdCommand, Warehouses>
        {
            private readonly IWarehouseDbContext _context;
            public DeleteWarehouseByIdCommandHandler(IWarehouseDbContext context)
            {
                _context = context;
            }
            public async Task<Warehouses> Handle(DeleteWarehouseByIdCommand command, CancellationToken cancellationToken)
            {
                var warehouse = await _context.Warehouses.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (warehouse == null) return default;
                _context.Warehouses.Remove(warehouse);
                await _context.SaveChangesAsync();
                return warehouse;
            }
        }
    }
}
