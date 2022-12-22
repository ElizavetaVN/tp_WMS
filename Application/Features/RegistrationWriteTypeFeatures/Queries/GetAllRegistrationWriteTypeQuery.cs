using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.RegistrationWriteTypeFeatures.Queries
{
    public class GetAllRegistrationWriteTypeQuery : IRequest<IEnumerable<RegistrationWriteType>>
    {

        public class GetAllRegistrationWriteTypeQueryHandler : IRequestHandler<GetAllRegistrationWriteTypeQuery, IEnumerable<RegistrationWriteType>>
        {
            private readonly IRegistrationWriteTypeDbContext _context;
            public GetAllRegistrationWriteTypeQueryHandler(IRegistrationWriteTypeDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<RegistrationWriteType>> Handle(GetAllRegistrationWriteTypeQuery query, CancellationToken cancellationToken)
            {
                var RegistrationWriteType = await _context.RegistrationWriteType.ToListAsync();
                if (RegistrationWriteType == null)
                {
                    return null;
                }
                return RegistrationWriteType.AsReadOnly();
            }
        }
    }
}