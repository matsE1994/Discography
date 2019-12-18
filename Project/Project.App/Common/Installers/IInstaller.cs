using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Project.App.Common.Installers
{
    public interface IInstaller
    {
        void Install(IServiceCollection services, IConfiguration configuration);
    }
}