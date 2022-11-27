using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Application.Interfaces;
using Domain;

namespace Application.Staff.Commands.CreateStaff
{
    public class CreateStaffCommandHandler //обработчик создания пользователя
    : IRequestHandler<CreateStaffCommand, Guid>
    {//содержит логику создания
        private readonly IStaffDbContext _dbContext;

        public CreateStaffCommandHandler(IStaffDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateStaffCommand request,//логика обработки команды
            CancellationToken cancellationToken) //формирование сотрудника, возвращаем ID созданного сотрудника
        {
            var staff = new Domain.Staff
            {
                Id = Guid.NewGuid(),
                Position=request.Position,
                Surname=request.Surname,
                Name=request.Name,
                DateOfBirth= request.DateOfBirth,
            };

            await _dbContext.Staff.AddAsync(staff, cancellationToken);//сохраниение изменения в БД
            await _dbContext.SaveChangesAsync(cancellationToken);

            return staff.Id;
        }
    }
}