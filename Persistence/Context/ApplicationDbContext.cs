using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class ApplicationDbContext :
            IdentityDbContext<IdentityUser>, 
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
            //modelBuilder.Entity<OrderStatus>().Property(p => p.Name).HasColumnType("nvarchar(50)");
            //modelBuilder.Entity<OrderType>().Property(p => p.Name).HasColumnType("nvarchar(50)");
            //modelBuilder.Entity<Partners>().Property(p => p.Name).HasColumnType("nvarchar(50)");
            //modelBuilder.Entity<Products>().Property(p => p.Name).HasColumnType("nvarchar(50)");
            modelBuilder.Entity<Realization>().Property(p => p.Data).HasColumnType("datetime");
            //modelBuilder.Entity<RealizationType>().Property(p => p.Name).HasColumnType("nvarchar(50)");
            modelBuilder.Entity<RegistrationWrite>().Property(p => p.Data).HasColumnType("datetime");
            //modelBuilder.Entity<RegistrationWriteType>().Property(p => p.Name).HasColumnType("nvarchar(50)");
            //modelBuilder.Entity<Units>().Property(p => p.Name).HasColumnType("nvarchar(50)");
            //modelBuilder.Entity<Warehouses>().Property(p => p.FullName).HasColumnType("nvarchar(500)");

            modelBuilder.Entity<OrderStatus>().HasData(new OrderStatus[] {
                new OrderStatus{Id = 1,Name="Без статуса"},
                new OrderStatus{Id = 2, Name="Новый"},
                new OrderStatus{Id = 3, Name="Ожидает проверки"},
                new OrderStatus{Id = 4, Name="Ожидает отгрузки"},
                new OrderStatus{Id = 5, Name="Принят"},
                new OrderStatus{Id = 6, Name="Выполнен"},
                new OrderStatus{Id = 7, Name="Отменен"},
            });
            modelBuilder.Entity<OrderType>().HasData(new OrderType[] {
                new OrderType{Id = 1,Name="Заказ клиента"},
                new OrderType{Id = 2, Name="Заказ поставщика"},
                new OrderType{Id = 3, Name="Все"},
            });
            modelBuilder.Entity<RegistrationWriteType>().HasData(new RegistrationWriteType[] {
                new RegistrationWriteType{Id = 1,Name="Оприходование"},
                new RegistrationWriteType{Id = 2, Name="Списание"},
            });
            modelBuilder.Entity<RealizationType>().HasData(new RealizationType[] {
                new RealizationType{Id = 1,Name="Реализация товаров"},
                new RealizationType{Id = 2, Name="Поступление товаров"},
            });

            modelBuilder.Entity<IdentityUser>(entity =>
            {
                entity.ToTable(name: "User");
            });
            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });

            base.OnModelCreating(modelBuilder);
        }
        
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

    }
}
