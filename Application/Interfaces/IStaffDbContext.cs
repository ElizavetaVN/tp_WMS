using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace Application.Interfaces
{
    public interface IStaffDbContext  //часть приложения, реализация во вне
    {
        DbSet<Domain.Staff> Staff { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
