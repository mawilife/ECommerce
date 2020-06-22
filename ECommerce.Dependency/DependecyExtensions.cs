using Microsoft.Extensions.DependencyInjection;
using System;

namespace ECommerce.Dependency
{
    public static class DependecyExtensions
    {
        public static void AddModule<TModule>(this IServiceCollection services) where TModule: IDependencyModule,new()
        {
            services.AddModule(new TModule());
        }
        public static void AddModule(this IServiceCollection services,IDependencyModule module)
        {
            module.Configure(services);
        }
    }
}
