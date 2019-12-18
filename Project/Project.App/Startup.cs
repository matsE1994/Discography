using System;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Project.App.Common;
using Project.App.Common.Configuration;
using Project.App.Common.Installers;

namespace Project.App
{
    public class Startup
    {
        public Startup(IHostEnvironment env, IConfiguration configuration)
        {
            Env = env ?? throw new ArgumentNullException(nameof(env));
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            ServiceProperties = Configuration.GetSection("ServiceProperties").Get<ServiceProperties>();
        }

        private ServiceProperties ServiceProperties { get; }
        private IConfiguration Configuration { get; }
        private IHostEnvironment Env { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //configure options
            services.Configure<AppSettings>(Configuration);
            services.AddTransient(p => p.GetRequiredService<IOptionsSnapshot<AppSettings>>().Value);

            //installers
            services.InvokeInstallersInAssembly(Configuration);
            
        }

        public void Configure(IApplicationBuilder app, IOptionsMonitor<AppSettings> optionsAccessor) =>
            app.UseRouting()
                .UseHttpsRedirection()
                .UseSwagger()
                .UseSwaggerUI(options =>
                {
                    var serviceProperties = optionsAccessor.CurrentValue.ServiceProperties;
                    options.SwaggerEndpoint($"/swagger/{serviceProperties.FullServiceName}/swagger.json",
                        serviceProperties.Name);
                    options.DocumentTitle = serviceProperties.Name;
                })
                .UseEndpoints(endpoints => endpoints.MapControllers());
    }
}