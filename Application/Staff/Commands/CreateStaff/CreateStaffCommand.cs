using System;
using MediatR;

namespace Application.Staff.Commands.CreateStaff
{//хранит информацию, что необходимо для создания сотрудника
    public class CreateStaffCommand : IRequest<Guid> //помечает результат выполнения команды, вернет результат определенного типа
    {
        public Guid Position { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
