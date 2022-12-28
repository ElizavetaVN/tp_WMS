using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.RealizationFeatures.Commands
{
    public class CreateRealizationCommand : IRequest<Realization>
    {
        public RealizationType RealizationType { get; set; }
        public DateTime Data { get; set; }
        public Orders Order { get; set; }
        public int Partners { get; set; }
        public int Warehouses { get; set; }
        public int Products { get; set; }
        public string Quantity { get; set; }
        public int Units { get; set; }
        public string Employee { get; set; }
        public string Comment { get; set; }
        public class CreateRealizationCommandHandler : IRequestHandler<CreateRealizationCommand, Realization>
        {
            private readonly IRealizationDbContext _context;
            public CreateRealizationCommandHandler(IRealizationDbContext context)
            {
                _context = context;
            }
            public async Task<Realization> Handle(CreateRealizationCommand command, CancellationToken cancellationToken)
            {
                var Realization = new Realization();
                Realization.RealizationType = command.RealizationType;
                Realization.Data = command.Data;
                Realization.Order = command.Order;
                Realization.Partners = command.Partners;
                Realization.Warehouses = command.Warehouses;
                Realization.Products = command.Products;
                Realization.Quantity = command.Quantity;
                Realization.Units = command.Units;
                Realization.Employee = command.Employee;
                Realization.Comment = command.Comment;
                _context.Realization.Add(Realization);
                await _context.SaveChangesAsync();
                return Realization;
            }
        }
    }
}
