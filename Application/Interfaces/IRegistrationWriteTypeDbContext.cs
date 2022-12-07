using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRegistrationWriteTypeDbContext
    {
        DbSet<RegistrationWriteType> RegistrationWriteType { get; set; }
        Task<int> SaveChangesAsync();
    }
}
