using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IOrderDbContext
    {
        DbSet<Orders> Orders { get; set; }
        Task<int> SaveChangesAsync();
    }
}
