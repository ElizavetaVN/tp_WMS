using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.RealizationFeatures.Commands
{
    public class UpdateRealizationCommand : IRequest<Realization>
    {
        public int Id { get; set; }
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
        public class UpdateRealizationCommandHandler : IRequestHandler<UpdateRealizationCommand, Realization>
        {
            private readonly IRealizationDbContext _context;
            public UpdateRealizationCommandHandler(IRealizationDbContext context)
            {
                _context = context;
            }
            public async Task<Realization> Handle(UpdateRealizationCommand command, CancellationToken cancellationToken)
            {
                var Realization = _context.Realization.Where(a => a.Id == command.Id).FirstOrDefault();

                if (Realization == null)
                {
                    return default;
                }
                else
                {
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
                    await _context.SaveChangesAsync();
                    return Realization;
                }
            }
        }
    }
}
