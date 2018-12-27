using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SportsNews.Web.Models;
using System;

namespace Sandbox
{
    using System.IO;
    using Microsoft.Extensions.Configuration;
    using SportsNews.Data;
    using SportsNews.Data.Common;

    public static class Program
    {
        public static object ApplicationDbContextSeeder { get; private set; }

        public static void Main(string[] args)
        {
            Console.WriteLine($"{typeof(Program).Namespace} ({string.Join(" ", args)}) starts working...");
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider(true);

            using (var serviceScope = serviceProvider.CreateScope())
            {
                serviceProvider = serviceScope.ServiceProvider;

                SandBoxCode(serviceProvider);
            }
        }

        private static void SandBoxCode(IServiceProvider serviceProvider)
        {
            // TODO: Code here  
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables()
                .Build();
            services.AddDbContext<SportsNewsContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")
                ));

            services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));

        }
    }
}
