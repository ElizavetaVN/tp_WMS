﻿using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.OrderFeatures.Queries;
using Application.Features.MovingFeatures.Queries;
using Application.Features.RegistrationWriteFeatures.Queries;
using Application.Features.InventoryFeatures.Queries;
using Application.Features.RealizationFeatures.Queries;

namespace Application.Features.ProductFeatures.Queries
{
    public class GetAllProductQuery : IRequest<IEnumerable<Products>>
    {

        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<Products>>
        {
            private readonly IMediator _mediator;
            private readonly IProductDbContext _context;
            public GetAllProductsQueryHandler(IProductDbContext context, IMediator mediator)
            {
                _mediator = mediator;
                _context = context;
            }
            public async Task<IEnumerable<Products>> Handle(GetAllProductQuery query, CancellationToken cancellationToken)
            {
                var prod = _context.Products.Include(p => p.Units);
                var prodLi = prod.Include(p => p.Provider);
                var productList = await prodLi.ToListAsync();

                var model1 = (await _mediator.Send(new GetAllOrderQuery()));
                var model2 = (await _mediator.Send(new GetAllMovingQuery()));
                var model3 = (await _mediator.Send(new GetAllRegistrationWriteQuery()));
                var model4 = (await _mediator.Send(new GetAllInventoryQuery()));
                var model5 = (await _mediator.Send(new GetAllRealizationQuery()));

                foreach (var unit in productList)
                {
                    foreach (var mod in model1)
                    {
                        if (unit == mod.Products && mod != null)
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
                        if (unit == mod.Products && mod != null)
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
                    foreach (var mod in model3)
                    {
                        if (unit == mod.Products && mod != null)
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
                    foreach (var mod in model4)
                    {
                        if (unit == mod.Products && mod != null)
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
                    foreach (var mod in model5)
                    {
                        if (unit == mod.Products && mod != null)
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
                if (productList == null)
                {
                    return null;
                }
                
                return productList.AsReadOnly();
            }
        }
    }
}
