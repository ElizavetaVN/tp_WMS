using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UnitFeatures.Commands
{
    public class CreateUnitCommand : IRequest<int>
    {
        public string Name { get; set; }

        public class CreateUnitCommandHandler : IRequestHandler<CreateUnitCommand, int>
        {
            private readonly IUnitDbContext _context;
            public CreateUnitCommandHandler(IUnitDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateUnitCommand command, CancellationToken cancellationToken)
            {
                var product = new Units();
                product.Name = command.Name;
                _context.Units.Add(product);
                await _context.SaveChangesAsync();
                return product.Id;
            }
        }
    }
}
