using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRegistrationWriteDbContext
    {
        DbSet<RegistrationWrite> RegistrationWrite { get; set; }
        Task<int> SaveChangesAsync();
    }
}
