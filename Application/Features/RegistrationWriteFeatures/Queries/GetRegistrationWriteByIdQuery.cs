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

namespace Application.Features.RegistrationWriteFeatures.Queries
{
    public class GetRegistrationWriteByIdQuery : IRequest<RegistrationWrite>
    {
        public int Id { get; set; }
        public class GetRegistrationWriteByIdQueryHandler : IRequestHandler<GetRegistrationWriteByIdQuery, RegistrationWrite>
        {
            private readonly IRegistrationWriteDbContext _context;
            public GetRegistrationWriteByIdQueryHandler(IRegistrationWriteDbContext context)
            {
                _context = context;
            }
            public async Task<RegistrationWrite> Handle(GetRegistrationWriteByIdQuery query, CancellationToken cancellationToken)
            {
                var RegistrationWrite1 = _context.RegistrationWrite.Include(p => p.Products.Units);
                var RegistrationWrite = RegistrationWrite1.Where(a => a.Id == query.Id).FirstOrDefault();
                if (RegistrationWrite == null) return null;
                return RegistrationWrite;
            }
        }
    }
}
