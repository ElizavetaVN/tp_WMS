using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.RegistrationWriteTypeFeatures.Queries
{
    public class GetRegistrationWriteTypeByIdQuery : IRequest<RegistrationWriteType>
    {
        public int Id { get; set; }
        public class GetRegistrationWriteTypeByIdQueryHandler : IRequestHandler<GetRegistrationWriteTypeByIdQuery, RegistrationWriteType>
        {
            private readonly IRegistrationWriteTypeDbContext _context;
            public GetRegistrationWriteTypeByIdQueryHandler(IRegistrationWriteTypeDbContext context)
            {
                _context = context;
            }
            public async Task<RegistrationWriteType> Handle(GetRegistrationWriteTypeByIdQuery query, CancellationToken cancellationToken)
            {
                var RegistrationWriteType = _context.RegistrationWriteType.Where(a => a.Id == query.Id).FirstOrDefault();
                if (RegistrationWriteType == null) return null;
                return RegistrationWriteType;
            }
        }
    }
}
