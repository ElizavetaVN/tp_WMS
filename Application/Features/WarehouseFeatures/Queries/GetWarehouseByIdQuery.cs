using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.WarehouseFeatures.Queries
{
    public class GetWarehouseByIdQuery : IRequest<Warehouses>
    {
        public int Id { get; set; }
        public class GetWarehouseByIdQueryHandler : IRequestHandler<GetWarehouseByIdQuery, Warehouses>
        {
            private readonly IWarehouseDbContext _context;
            public GetWarehouseByIdQueryHandler(IWarehouseDbContext context)
            {
                _context = context;
            }
            public async Task<Warehouses> Handle(GetWarehouseByIdQuery query, CancellationToken cancellationToken)
            {
                var Warehouse = _context.Warehouses.Where(a => a.Id == query.Id).FirstOrDefault();
                if (Warehouse == null) return null;
                return Warehouse;
            }
        }
    }
}
