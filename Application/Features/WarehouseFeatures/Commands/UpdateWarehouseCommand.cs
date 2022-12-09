﻿using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.WarehouseFeatures.Commands
{
    public class UpdateOrderCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public class UpdateWarehouseCommandHandler : IRequestHandler<UpdateOrderCommand, int>
        {
            private readonly IWarehouseDbContext _context;
            public UpdateWarehouseCommandHandler(IWarehouseDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
            {
                var warehouse = _context.Warehouses.Where(a => a.Id == command.Id).FirstOrDefault();

                if (warehouse == null)
                {
                    return default;
                }
                else
                {
                    warehouse.FullName = command.FullName;
                    warehouse.Name = command.Name;
                    await _context.SaveChangesAsync();
                    return warehouse.Id;
                }
            }
        }
    }
}
