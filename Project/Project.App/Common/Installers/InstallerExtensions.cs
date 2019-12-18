using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Project.App.Common.Installers
{
    public static class InstallerExtensions
    {
        private static bool IsInstaller(Type type) =>
            typeof(IInstaller).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract;

        private static IEnumerable<IInstaller> LoadInstallersFromAssemblies(this IEnumerable<Type> types) => types
            .Where(IsInstaller)
            .Select(Activator.CreateInstance)
            .Cast<IInstaller>();

        public static void InvokeInstallersInAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            var installers = typeof(Startup)
                .Assembly
                .ExportedTypes
                .LoadInstallersFromAssemblies()
                .ToList();

            installers.ForEach(installer => installer.Install(services, configuration));
        }
    }
}