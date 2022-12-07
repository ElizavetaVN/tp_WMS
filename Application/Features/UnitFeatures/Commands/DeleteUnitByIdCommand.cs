using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UnitFeatures.Commands
{
    public class DeleteUnitByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteUnitByIdCommandHandler : IRequestHandler<DeleteUnitByIdCommand, int>
        {
            private readonly IUnitDbContext _context;
            public DeleteUnitByIdCommandHandler(IUnitDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteUnitByIdCommand command, CancellationToken cancellationToken)
            {
                var unit = await _context.Units.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (unit == null) return default;
                _context.Units.Remove(unit);
                await _context.SaveChangesAsync();
                return unit.Id;
            }
        }
    }
}
