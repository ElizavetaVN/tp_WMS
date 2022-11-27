using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Application.Interfaces;

namespace Persistence
{
    public static class DependencyInjection//добавление контекста БД в приложение
    {
        public static IServiceCollection AddPersistence//добавление использования констекста БД, его регистрация
            (this IServiceCollection 
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<StaffDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IStaffDbContext>(provider =>
                provider.GetService<StaffDbContext>());
            return services;
        }
    }
}
