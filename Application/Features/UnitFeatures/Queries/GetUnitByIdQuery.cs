using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UnitFeatures.Queries
{
    public class GetUnitByIdQuery : IRequest<Units>
    {
        public int Id { get; set; }
        public class GetUnitByIdQueryHandler : IRequestHandler<GetUnitByIdQuery, Units>
        {
            private readonly IUnitDbContext _context;
            public GetUnitByIdQueryHandler(IUnitDbContext context)
            {
                _context = context;
            }
            public async Task<Units> Handle(GetUnitByIdQuery query, CancellationToken cancellationToken)
            {
                var unit = _context.Units.Where(a => a.Id == query.Id).FirstOrDefault();
                if (unit == null) return null;
                return unit;
            }
        }
    }
}
