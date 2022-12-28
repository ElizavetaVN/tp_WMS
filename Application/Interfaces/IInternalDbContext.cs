using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IInternalDbContext
    {
        DbSet<Internal> Internal { get; set; }
        Task<int> SaveChangesAsync();
    }
}
