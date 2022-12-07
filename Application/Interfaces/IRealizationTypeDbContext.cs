using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRealizationTypeDbContext
    {
        DbSet<RealizationType> RealizationType { get; set; }
        Task<int> SaveChangesAsync();
    }
}
