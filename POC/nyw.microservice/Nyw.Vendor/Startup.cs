using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Winton.Extensions.Configuration.Consul;

namespace Nyw.VendorService {
    public class Startup {
        public Startup(IConfiguration configuration, IHostingEnvironment env) {
            HostingEnvironment = env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment HostingEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime appLifetime) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            appLifetime.ApplicationStopping.Register(cancellationTokenSource.Cancel);
            app.UseMvc();
        }
    private static CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
    public static void ConfigureAppConfiguration(WebHostBuilderContext hostingContext, IConfigurationBuilder builder) {
        var env = hostingContext.HostingEnvironment;
        builder
            .AddConsul($"{env.ApplicationName}.{env.EnvironmentName}",
                cancellationTokenSource.Token,
                options => {
                    options.ConsulConfigurationOptions =
                        cco => {
                            cco.Address = new Uri("http://localhost:8500");
                            cco.Datacenter = "dc1";
                        };
                    options.Optional = true;
                    options.ReloadOnChange = true;
                    options.OnLoadException = exceptionContext => { exceptionContext.Ignore = true; };
                })
            .AddEnvironmentVariables();
    }
    }
}
