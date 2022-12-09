using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.WarehouseFeatures.Queries
{
    public class GetAllOrderQuery : IRequest<IEnumerable<Warehouses>>
    {

        public class GetAllWarehousesQueryHandler : IRequestHandler<GetAllOrderQuery, IEnumerable<Warehouses>>
        {
            private readonly IWarehouseDbContext _context;
            public GetAllWarehousesQueryHandler(IWarehouseDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Warehouses>> Handle(GetAllOrderQuery query, CancellationToken cancellationToken)
            {
                var WarehouseList = await _context.Warehouses.ToListAsync();
                if (WarehouseList == null)
                {
                    return null;
                }
                return WarehouseList.AsReadOnly();
            }
        }
    }
}
