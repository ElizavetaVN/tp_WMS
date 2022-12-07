using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IOrderStatusDbContext
    {
        DbSet<OrderStatus> OrderStatus { get; set; }
        Task<int> SaveChangesAsync();
    }
}
