using System.IO;
using System.Reflection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nyw.Configuration.SqlServer;

namespace Nyw.Configuration.SqlServer.Host {
    public class Program {
        public static void Main(string[] args) {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) => {
                var builtConfig = config.Build();
                var dbConnStr = builtConfig.GetConnectionString("AppConfigDB");
                var migrationsAssembly = typeof(Program).GetTypeInfo().Assembly.GetName().Name;
                config.SetBasePath(Directory.GetCurrentDirectory());
                config.AddSqlServerConfiguration((options) => {
                    options.UseSqlServer(dbConnStr, sql => sql.MigrationsAssembly(migrationsAssembly));
                });
            })
            .Configure(appBuilder=> {
                appBuilder.UseSqlServerConfiguration();
            })
            .UseStartup<Startup>();
    }
}
