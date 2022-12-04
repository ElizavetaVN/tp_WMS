using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Products>>
    {

        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Products>>
        {
            private readonly IProductDbContext _context;
            public GetAllProductsQueryHandler(IProductDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Products>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
            {
                var productList = await _context.Products.ToListAsync();
                if (productList == null)
                {
                    return null;
                }
                return productList.AsReadOnly();
            }
        }
    }
}
