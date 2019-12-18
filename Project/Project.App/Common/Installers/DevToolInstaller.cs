using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Project.App.Common.Configuration;

namespace Project.App.Common.Installers
{
    public class DevToolInstaller : IInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            var properties = configuration.GetSection("ServiceProperties").Get<ServiceProperties>();
            var contact = configuration.GetSection("Contact").Get<Contact>();
            services.AddSwaggerGen((c) =>
            {
                c.SwaggerDoc(properties.FullServiceName,
                    new OpenApiInfo
                    {
                        Title = properties.Name,
                        Version = properties.Version,
                        Contact = new OpenApiContact
                        {
                            Email = contact.Email,
                            Name = contact.Name
                        }
                    });
            });
        }
    }
}