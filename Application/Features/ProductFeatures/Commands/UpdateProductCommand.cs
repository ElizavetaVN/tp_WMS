using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.UnitFeatures.Queries;
using Application.Features.ProductFeatures.Queries;
using Application.Features.PartnerFeatures.Queries;

namespace Application.Features.ProductFeatures.Commands
{
    public class UpdateProductCommand : IRequest<Products>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ArticleNumber { get; set; }
        public int Provider { get; set; }
        public int Units { get; set; }
        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Products>
        {
            private readonly IMediator _mediator;
            private readonly IProductDbContext _context;
            public UpdateProductCommandHandler(IProductDbContext context, IMediator mediator)
            {
                _mediator = mediator;
                _context = context;
            }
            public async Task<Products> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
            {
                var product = _context.Products.Where(a => a.Id == command.Id).FirstOrDefault();

                if (product == null)
                {
                    return default;
                }
                else
                {
                    var model = (await _mediator.Send(new GetUnitByIdQuery { Id = command.Units }));
                    var model1 = (await _mediator.Send(new GetPartnerByIdQuery { Id = command.Provider }));
                    product.ArticleNumber = command.ArticleNumber;
                    product.Name = command.Name;
                    product.Provider = model1;
                    product.Units = model;
                    model.Status = true;
                    await _context.SaveChangesAsync();
                    return product;
                }
            }
        }
    }
}
