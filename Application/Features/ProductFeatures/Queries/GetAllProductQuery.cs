using Application.Interfaces;
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
                var model2 = (await _mediator.Send(new GetAllMovingQuery()));//
                var model3 = (await _mediator.Send(new GetAllRegistrationWriteQuery()));
                var model4 = (await _mediator.Send(new GetAllInventoryQuery()));
                var model5 = (await _mediator.Send(new GetAllRealizationQuery()));

                foreach (var unit in productList)
                {
                    foreach (var mod1 in model1)
                    {
                        foreach (var mod2 in model2)
                        {
                            foreach (var mod3 in model3)
                            {
                                foreach (var mod4 in model4)
                                {
                                    foreach (var mod5 in model5)
                                    {
                                        if (unit == mod1.Products && mod1 != null)
                                        {
                                            unit.Status = true;
                                            await _context.SaveChangesAsync();
                                            break;
                                        }
                                        else if (unit == mod2.Products && mod2 != null)
                                        {
                                            unit.Status = true;
                                            await _context.SaveChangesAsync();
                                            break;
                                        }
                                        else if (unit == mod3.Products && mod3 != null)
                                        {
                                            unit.Status = true;
                                            await _context.SaveChangesAsync();
                                            break;
                                        }
                                        else if (unit == mod4.Products && mod4 != null)
                                        {
                                            unit.Status = true;
                                            await _context.SaveChangesAsync();
                                            break;
                                        }
                                        else if (unit == mod5.Products && mod5 != null)
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
                            }
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
