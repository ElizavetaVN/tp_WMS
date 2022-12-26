using Application.Features.ProductFeatures.Queries;
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
            private readonly IMediator _mediator;
            public UpdateUnitCommandHandler(IUnitDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }
            public async Task<Units> Handle(UpdateUnitCommand command, CancellationToken cancellationToken)
            {
                var unit = _context.Units.Where(a => a.Id == command.Id).FirstOrDefault();

                var models = (await _mediator.Send(new GetAllProductQuery()));
                foreach (var units in _context.Units)
                {
                    foreach (var prod in models)
                    {
                        if (units == prod.Units && prod != null)
                        {
                            units.Status = true;
                            //await _context.SaveChangesAsync();
                            break;
                        }
                        else
                        {
                            units.Status = false;
                            //await _context.SaveChangesAsync();
                        }
                    }
                }

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
