using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMovingDbContext
    {
        DbSet<Moving> Moving { get; set; }
        Task<int> SaveChangesAsync();
    }
}
