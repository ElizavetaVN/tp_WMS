using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IInternalOperationDbContext
    {
        DbSet<InternalOperation> InternalOperation { get; set; }
        Task<int> SaveChangesAsync();
    }
}
