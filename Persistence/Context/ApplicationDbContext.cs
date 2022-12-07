using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class ApplicationDbContext : 
            DbContext, 
            IInventoryDbContext, 
            IMovingDbContext, 
            IOrderDbContext, 
            IOrderStatusDbContext, 
            IOrderTypeDbContext, 
            IPartnerDbContext, 
            IProductDbContext, 
            IRealizationDbContext,
            IRealizationTypeDbContext,
            IRegistrationWriteDbContext,
            IRegistrationWriteTypeDbContext,
            IUnitDbContext, 
            IWarehouseDbContext
    {
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Moving> Moving { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<OrderType> OrderType { get; set; }
        public DbSet<Partners> Partners { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Realization> Realization { get; set; }
        public DbSet<RealizationType> RealizationType { get; set; }
        public DbSet<RegistrationWrite> RegistrationWrite { get; set; }
        public DbSet<RegistrationWriteType> RegistrationWriteType { get; set; }
        public DbSet<Units> Units { get; set; }
        public DbSet<Warehouses> Warehouses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>().Property(p => p.Data).HasColumnType("datetime");
            modelBuilder.Entity<Moving>().Property(p => p.Data).HasColumnType("datetime");
            modelBuilder.Entity<Orders>().Property(p => p.Data).HasColumnType("datetime");
            modelBuilder.Entity<OrderStatus>().Property(p => p.Name).HasColumnType("nvarchar(50)");
            modelBuilder.Entity<OrderType>().Property(p => p.Name).HasColumnType("nvarchar(50)");
            modelBuilder.Entity<Partners>().Property(p => p.Name).HasColumnType("nvarchar(50)");
            modelBuilder.Entity<Products>().Property(p => p.Name).HasColumnType("nvarchar(50)");
            modelBuilder.Entity<Realization>().Property(p => p.Data).HasColumnType("datetime");
            modelBuilder.Entity<RealizationType>().Property(p => p.Name).HasColumnType("nvarchar(50)");
            modelBuilder.Entity<RegistrationWrite>().Property(p => p.Data).HasColumnType("datetime");
            modelBuilder.Entity<RegistrationWriteType>().Property(p => p.Name).HasColumnType("nvarchar(50)");
            modelBuilder.Entity<Units>().Property(p => p.Name).HasColumnType("nvarchar(50)");
            modelBuilder.Entity<Warehouses>().Property(p => p.FullName).HasColumnType("nvarchar(500)");

            base.OnModelCreating(modelBuilder);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

    }
}
