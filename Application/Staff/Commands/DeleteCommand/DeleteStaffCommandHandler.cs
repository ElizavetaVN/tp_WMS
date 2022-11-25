using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Application.Interfaces;
using Application.Common.Exceptions;
using Domain;

namespace Application.Staff.Commands.DeleteCommand
{
    public class DeleteStaffCommandHandler : IRequestHandler<DeleteStaffCommand>
    {
        private readonly IStaffDbContext _dbContext;

        public DeleteStaffCommandHandler(IStaffDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteStaffCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Staff
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.Position != request.Position)
            {
                throw new NotFoundException(nameof(Domain.Staff), request.Id);
            }

            _dbContext.Staff.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
