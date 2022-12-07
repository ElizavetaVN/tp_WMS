using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUnitDbContext
    {
        DbSet<Units> Units { get; set; }
        Task<int> SaveChangesAsync();
    }
}
