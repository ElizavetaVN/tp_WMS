using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.UnitFeatures.Queries;

namespace Application.Features.ProductFeatures.Commands
{
    public class CreateProductCommand : IRequest<Products>
    {
        public string Name { get; set; }
        public int ArticleNumber { get; set; }
        public Partners Provider { get; set; }
        public int Units { get; set; }
        public bool Status { get; set; }
        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Products>
        {
            private readonly IMediator _mediator;
            private readonly IProductDbContext _context;
            public CreateProductCommandHandler(IProductDbContext context, IMediator mediator)
            {
                _mediator = mediator;
                _context = context;
            }
            
            public async Task<Products> Handle(CreateProductCommand command, CancellationToken cancellationToken)
            {
                
                var model = (await _mediator.Send(new GetUnitByIdQuery { Id = command.Units }));
                var product = new Products();
                
                product.ArticleNumber = command.ArticleNumber;
                product.Name = command.Name;
                product.Provider = command.Provider;
                product.Units = model;
                model.Status = true;
                product.Status = command.Status;
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return product;
            }
        }
    }
}
