using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UnitFeatures.Commands
{
    public class UpdateUnitCommand : IRequest<Units>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateUnitCommandHandler : IRequestHandler<UpdateUnitCommand, Units>
        {
            private readonly IUnitDbContext _context;
            public UpdateUnitCommandHandler(IUnitDbContext context)
            {
                _context = context;
            }
            public async Task<Units> Handle(UpdateUnitCommand command, CancellationToken cancellationToken)
            {
                var unit = _context.Units.Where(a => a.Id == command.Id).FirstOrDefault();

                if (unit == null)
                {
                    return default;
                }
                else
                {
                    unit.Name = command.Name;
                    await _context.SaveChangesAsync();
                    return unit;
                }
            }
        }
    }
}
