using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Project.App.Common.Installers
{
    public class WebInstaller : IInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
        }
    }
}