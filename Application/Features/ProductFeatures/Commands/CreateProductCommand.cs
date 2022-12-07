using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; }
        public int ArticleNumber { get; set; }
        public Partners Provider { get; set; }
        public  Units Units { get; set; }
        public bool Status { get; set; }
        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
        {
            private readonly IProductDbContext _context;
            public CreateProductCommandHandler(IProductDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken)
            {
                var product = new Products();
                product.ArticleNumber = command.ArticleNumber;
                product.Name = command.Name;
                product.Provider = command.Provider;
                product.Units = command.Units;
                product.Status = command.Status;
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return product.Id;
            }
        }
    }
}
