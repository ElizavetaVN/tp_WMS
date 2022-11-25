using System;

namespace Domain
{
    public class Staff //пользователь
    {
        public Guid Id { get; set; }
        public Guid Position {get; set;}
        public string Surname { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
