using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using Serilog;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persistence;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            //������� ����� ������������� ����
            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;//������������ ��� ���������� ������������
                try
                {
                    var context = serviceProvider.GetRequiredService<StaffDbContext>();
                    DbInitializer.Initialize(context);//����� ������ ������������� ����, �������� ���� ���������
                }
                catch (Exception exception)
                {
                    Log.Fatal(exception, "An error occurred while app initialization");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
