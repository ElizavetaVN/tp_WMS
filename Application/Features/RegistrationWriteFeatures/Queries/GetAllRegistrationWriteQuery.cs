using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.RegistrationWriteFeatures.Queries
{
    public class GetAllRegistrationWriteQuery : IRequest<IEnumerable<RegistrationWrite>>
    {

        public class GetAllRegistrationWriteQueryHandler : IRequestHandler<GetAllRegistrationWriteQuery, IEnumerable<RegistrationWrite>>
        {
            private readonly IRegistrationWriteDbContext _context;
            public GetAllRegistrationWriteQueryHandler(IRegistrationWriteDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<RegistrationWrite>> Handle(GetAllRegistrationWriteQuery query, CancellationToken cancellationToken)
            {
                var RegistrationWrite = await _context.RegistrationWrite.ToListAsync();
                if (RegistrationWrite == null)
                {
                    return null;
                }
                return RegistrationWrite.AsReadOnly();
            }
        }
    }
}
