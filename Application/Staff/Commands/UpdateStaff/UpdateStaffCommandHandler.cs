using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Application.Common.Exceptions;
using Domain;

namespace Application.Staff.Commands.UpdateStaff
{
    public class UpdateStaffCommandHandler : IRequestHandler<UpdateStaffCommand>
    {
        private readonly IStaffDbContext _dbContext;

        public UpdateStaffCommandHandler(IStaffDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateStaffCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Staff.FirstOrDefaultAsync(staff =>
                    staff.Id == request.Id, cancellationToken);

            if (entity == null || entity.Position != request.Position)
            {
                throw new NotFoundException(nameof(Domain.Staff), request.Id);
            }

            entity.Surname = request.Surname;
            entity.Name = request.Name;
            entity.DateOfBirth = request.DateOfBirth;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
