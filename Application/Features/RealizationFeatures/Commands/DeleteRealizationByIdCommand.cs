using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.RealizationFeatures.Commands
{
    public class DeleteRealizationByIdCommand : IRequest<Realization>
    {
        public int Id { get; set; }
        public class DeleteRealizationByIdCommandHandler : IRequestHandler<DeleteRealizationByIdCommand, Realization>
        {
            private readonly IRealizationDbContext _context;
            public DeleteRealizationByIdCommandHandler(IRealizationDbContext context)
            {
                _context = context;
            }
            public async Task<Realization> Handle(DeleteRealizationByIdCommand command, CancellationToken cancellationToken)
            {
                var Realization = await _context.Realization.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (Realization == null) return default;
                _context.Realization.Remove(Realization);
                await _context.SaveChangesAsync();
                return Realization;
            }
        }
    }
}
