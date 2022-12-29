using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IInventoryDbContext>(provider =>
                provider.GetService<ApplicationDbContext>());

            services.AddScoped<IMovingDbContext>(provider =>
                provider.GetService<ApplicationDbContext>());

            services.AddScoped<IOrderDbContext>(provider =>
                provider.GetService<ApplicationDbContext>());

            services.AddScoped<IOrderStatusDbContext>(provider =>
                provider.GetService<ApplicationDbContext>());

            services.AddScoped<IOrderTypeDbContext>(provider =>
                provider.GetService<ApplicationDbContext>());

            services.AddScoped<IPartnerDbContext>(provider =>
                provider.GetService<ApplicationDbContext>());

            services.AddScoped<IProductDbContext>(provider =>
                provider.GetService<ApplicationDbContext>());

            services.AddScoped<IRealizationDbContext>(provider =>
                provider.GetService<ApplicationDbContext>());

            services.AddScoped<IRealizationTypeDbContext>(provider =>
                provider.GetService<ApplicationDbContext>());

            services.AddScoped<IRegistrationWriteDbContext>(provider =>
                provider.GetService<ApplicationDbContext>());

            services.AddScoped<IRegistrationWriteTypeDbContext>(provider =>
                provider.GetService<ApplicationDbContext>());

            services.AddScoped<IUnitDbContext>(provider =>
                provider.GetService<ApplicationDbContext>());

            services.AddScoped<IWarehouseDbContext>(provider =>
                provider.GetService<ApplicationDbContext>());

            services.AddScoped<IInternalDbContext>(provider =>
                provider.GetService<ApplicationDbContext>());

            services.AddScoped<IInternalOperationDbContext>(provider =>
                provider.GetService<ApplicationDbContext>());


        }
    }
}

