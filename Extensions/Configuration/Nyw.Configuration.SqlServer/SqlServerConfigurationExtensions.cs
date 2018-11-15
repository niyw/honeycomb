using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Nyw.Configuration.SqlServer {
    public static class SqlServerConfigurationExtensions {
        public static IConfigurationBuilder AddSqlServerConfiguration(this IConfigurationBuilder builder,Action<DbContextOptionsBuilder> optionsAction) {
            
            return builder.Add(new SqlServerConfigurationSource(optionsAction));
        }
        public static IApplicationBuilder UseSqlServerConfiguration(this IApplicationBuilder app) {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope()) {
                serviceScope.ServiceProvider.GetRequiredService<AppConfigDbContext>().Database.Migrate();
            }
            return app;
        }
    }
}
