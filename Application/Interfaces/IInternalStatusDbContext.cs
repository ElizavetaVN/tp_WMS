using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IInternalStatusDbContext
    {
        DbSet<InternalStatus> InternalStatus { get; set; }
        Task<int> SaveChangesAsync();
    }
}
