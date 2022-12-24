using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
    public class DeleteProductByIdCommand : IRequest<Products>
    {
        public int Id { get; set; }
        public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, Products>
        {
            private readonly IProductDbContext _context;
            public DeleteProductByIdCommandHandler(IProductDbContext context)
            {
                _context = context;
            }
            public async Task<Products> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
            {
                var product = await _context.Products.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if ((product == null) && (product.Status != true)) return default;
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return product;
            }
        }
    }
}
