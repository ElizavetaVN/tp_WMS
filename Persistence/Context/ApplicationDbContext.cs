using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class ApplicationDbContext : DbContext, IProductDbContext, IUnitDbContext
    {
        public DbSet<Products> Products { get; set; }
        public DbSet<Units> Units { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().Property(p => p.Name).HasColumnType("nvarchar(500)");
            modelBuilder.Entity<Units>().Property(p => p.Name).HasColumnType("nvarchar(50)");

            base.OnModelCreating(modelBuilder);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

    }
}
