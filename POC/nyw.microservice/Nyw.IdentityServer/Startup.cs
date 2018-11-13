using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.Models;
using IdentityServer4.EntityFramework.Mappers;
using System.Linq;

namespace Nyw.IdentityServer {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            ConfigureIdentityServerServices(services);
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                InitializeIdentityServerDatabase(app);
            }
            app.UseMvc();
        }
        private void ConfigureIdentityServerServices(IServiceCollection services) {
            var idpDbConnStr = Configuration.GetConnectionString("IdpDbConnStr");
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddUserModel()
                .AddConfigurationStore(options => {
                    options.ConfigureDbContext = builder =>
                        builder.UseSqlServer(idpDbConnStr,
                            sql => sql.MigrationsAssembly(migrationsAssembly));
                })
                .AddOperationalStore(options => {
                    options.ConfigureDbContext = builder =>
                        builder.UseSqlServer(idpDbConnStr,
                            sql => sql.MigrationsAssembly(migrationsAssembly));
                    options.EnableTokenCleanup = true;
                    options.TokenCleanupInterval = 30;
                });

        }
        private void InitializeIdentityServerDatabase(IApplicationBuilder app) {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope()) {
                serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();
                var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                context.Database.Migrate();
                if (!context.Clients.Any()) {
                    var client1 = new IdentityServer4.Models.Client {
                        ClientId = "demo.client1",
                        AllowedGrantTypes = GrantTypes.ClientCredentials,
                        ClientSecrets = {
                            new IdentityServer4.Models.Secret("secret".Sha256())
                        },
                        AllowedScopes = { "demo.api1" },
                        ClientName = "Demo Client1"
                    };
                    context.Clients.Add(client1.ToEntity());
                    context.SaveChanges();
                }

                if (!context.ApiResources.Any()) {
                    var api1 = new IdentityServer4.Models.ApiResource {
                        Name = "demo.api1",
                        DisplayName = "demo api",
                        Description = "this is just for demo"
                    };
                    context.ApiResources.Add(api1.ToEntity());
                    context.SaveChanges();
                }
            }
        }
    }
}
