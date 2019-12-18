using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Project.App.Common.Installers
{
    public class SystemInstaller : IInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddLogging();
            services.AddMediatR(typeof(Startup));
            services.AddAutoMapper(typeof(Startup));
        }
    }
}