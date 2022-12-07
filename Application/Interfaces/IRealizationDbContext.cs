using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRealizationDbContext
    {
        DbSet<Realization> Realization { get; set; }
        Task<int> SaveChangesAsync();
    }
}
