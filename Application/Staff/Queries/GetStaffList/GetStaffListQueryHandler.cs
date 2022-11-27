using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Application.Staff.Queries.GetStaffList
{
    public class GetStaffListQueryHandler : IRequestHandler<GetStaffListQuery, StaffListVm>
    {
        private readonly IStaffDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetStaffListQueryHandler(IStaffDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<StaffListVm> Handle(GetStaffListQuery request,
            CancellationToken cancellationToken)
        {
            var staffQuery = await _dbContext.Staff
                .Where(staff => staff.Position == request.Position)
                .ProjectTo<StaffLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new StaffListVm { Staff = staffQuery };
        }
    }
}
