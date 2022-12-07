using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPartnerDbContext
    {
        DbSet<Partners> Partners { get; set; }
        Task<int> SaveChangesAsync();
    }
}
