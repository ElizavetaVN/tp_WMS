using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Application.Common.Exceptions;
using Domain;

namespace Application.Staff.Queries.GetStaffDetails
{
    public class GetStaffDetailsQueryHandler : IRequestHandler<GetStaffDetailsQuery, StaffDetailsVm>//класс-обработчик
    {
        private readonly IStaffDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetStaffDetailsQueryHandler(IStaffDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<StaffDetailsVm> Handle(GetStaffDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Staff
                .FirstOrDefaultAsync(staff =>
                staff.Id == request.Id, cancellationToken);

            if (entity == null || entity.Position != request.Position)
            {
                throw new NotFoundException(nameof(Domain.Staff), request.Id);
            }

            return _mapper.Map<StaffDetailsVm>(entity);
        }
    }
}
