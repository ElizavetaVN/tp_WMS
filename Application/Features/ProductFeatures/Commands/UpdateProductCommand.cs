using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
    public class UpdateProductCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ArticleNumber { get; set; }
        public Partners Provider { get; set; }
        public Units Units { get; set; }
        public bool Status { get; set; }
        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
        {
            private readonly IProductDbContext _context;
            public UpdateProductCommandHandler(IProductDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
            {
                var product = _context.Products.Where(a => a.Id == command.Id).FirstOrDefault();

                if (product == null)
                {
                    return default;
                }
                else
                {
                    product.ArticleNumber = command.ArticleNumber;
                    product.Name = command.Name;
                    product.Provider = command.Provider;
                    product.Units = command.Units;
                    product.Status = command.Status;
                    await _context.SaveChangesAsync();
                    return product.Id;
                }
            }
        }
    }
}
