using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.UnitFeatures.Queries;
using Application.Features.OrderFeatures.Queries;

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

                var models = (await _mediator.Send(new GetAllOrderQuery()));
                foreach (var unit in productList)
                {
                    foreach (var mod in models)
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
