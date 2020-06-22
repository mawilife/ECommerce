using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Dependency
{
    public interface IDependencyModule
    {
        void Configure(IServiceCollection services);
    }
}
