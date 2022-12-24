using Application.Interfaces;
using Domain.Entities;
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
    public class DeleteUnitByIdCommand : IRequest<Units>
    {
        public int Id { get; set; }
        public class DeleteUnitByIdCommandHandler : IRequestHandler<DeleteUnitByIdCommand, Units>
        {
            private readonly IUnitDbContext _context;
            public DeleteUnitByIdCommandHandler(IUnitDbContext context)
            {
                _context = context;
            }
            public async Task<Units> Handle(DeleteUnitByIdCommand command, CancellationToken cancellationToken)
            {
                var unit = await _context.Units.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if ((unit == null) && (unit.Status != true)) return default;
                _context.Units.Remove(unit);
                await _context.SaveChangesAsync();
                return unit;
            }
        }
    }
}
