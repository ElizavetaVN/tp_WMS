using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IOrderTypeDbContext
    {
        DbSet<OrderType> OrderType { get; set; }
        Task<int> SaveChangesAsync();
    }
}
