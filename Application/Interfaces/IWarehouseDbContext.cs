using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IWarehouseDbContext
    {
        DbSet<Warehouses> Warehouses { get; set; }
        Task<int> SaveChangesAsync();
    }
}
