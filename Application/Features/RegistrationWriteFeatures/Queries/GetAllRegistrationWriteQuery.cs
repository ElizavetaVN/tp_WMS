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
            private readonly IMediator _mediator;
            private readonly IRegistrationWriteDbContext _context;
            public GetAllRegistrationWriteQueryHandler(IRegistrationWriteDbContext context, IMediator mediator)
            {
                _mediator = mediator;
                _context = context;
            }
            public async Task<IEnumerable<RegistrationWrite>> Handle(GetAllRegistrationWriteQuery query, CancellationToken cancellationToken)
            {
                var RegistrationWrite1 =  _context.RegistrationWrite.Include(p => p.RegistrationWriteType);
                var RegistrationWrite2 = RegistrationWrite1.Include(p => p.Inventory);
                var RegistrationWrite3 = RegistrationWrite2.Include(p => p.Warehouses);
                var RegistrationWrite4 = RegistrationWrite3.Include(p => p.Products);
                var RegistrationWrite5 = RegistrationWrite4.Include(p => p.Units);
                var RegistrationWrite = await RegistrationWrite5.ToListAsync();
                if (RegistrationWrite == null)
                {
                    return null;
                }
                return RegistrationWrite.AsReadOnly();
            }
        }
    }
}
