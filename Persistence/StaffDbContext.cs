using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Domain;
using Persistence.EntityTypeConfiguration;

namespace Persistence
{
    public class StaffDbContext : DbContext, IStaffDbContext //реализация интерфейса 
    {
        public DbSet<Staff> Staff { get; set; }

        public StaffDbContext(DbContextOptions<StaffDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new StaffConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
