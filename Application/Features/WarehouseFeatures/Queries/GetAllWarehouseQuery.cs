using Application.Features.MovingFeatures.Queries;
using Application.Features.OrderFeatures.Queries;
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
    public class GetAllWarehouseQuery : IRequest<IEnumerable<Warehouses>>
    {

        public class GetAllWarehousesQueryHandler : IRequestHandler<GetAllWarehouseQuery, IEnumerable<Warehouses>>
        {
            private readonly IMediator _mediator;
            private readonly IWarehouseDbContext _context;
            public GetAllWarehousesQueryHandler(IWarehouseDbContext context, IMediator mediator)
            {
                _mediator = mediator;
                _context = context;
            }
            public async Task<IEnumerable<Warehouses>> Handle(GetAllWarehouseQuery query, CancellationToken cancellationToken)
            {
                var WarehouseList = await _context.Warehouses.ToListAsync();

                var model1 = (await _mediator.Send(new GetAllOrderQuery()));
                var model2 = (await _mediator.Send(new GetAllMovingQuery()));

                foreach (var unit in WarehouseList)
                {
                    foreach (var mod in model1)
                    {
                        if (unit == mod.Warehouses && mod != null)
                        {
                            unit.Status = true;
                            await _context.SaveChangesAsync();
                            break;
                        }
                        else
                        {
                            unit.Status = false;
                            await _context.SaveChangesAsync();
                        }
                    }
                    foreach (var mod in model2)
                    {
                        if (unit == mod.WarehousesFrom  && mod != null)
                        {
                            unit.Status = true;
                            await _context.SaveChangesAsync();
                            break;
                        }
                        if (unit == mod.WarehousesTo && mod != null)
                        {
                            unit.Status = true;
                            await _context.SaveChangesAsync();
                            break;
                        }
                        else
                        {
                            unit.Status = false;
                            await _context.SaveChangesAsync();
                        }
                    }
                }

                if (WarehouseList == null)
                {
                    return null;
                }
                return WarehouseList.AsReadOnly();
            }
        }
    }
}
