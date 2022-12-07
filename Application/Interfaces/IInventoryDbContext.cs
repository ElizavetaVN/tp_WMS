using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IInventoryDbContext
    {
        DbSet<Inventory> Inventory { get; set; }
        Task<int> SaveChangesAsync();
    }
}
