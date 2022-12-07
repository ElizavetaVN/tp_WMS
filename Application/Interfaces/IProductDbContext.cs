using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductDbContext
    {
        DbSet<Products> Products { get; set; }
        Task<int> SaveChangesAsync();
    }
}