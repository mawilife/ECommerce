using AutoMapper;
using System;

namespace ECommerce.Mapping
{
    public static class AutoMapperExtensions
    {
        public static void AddModule<TModule>(this IMapperConfigurationExpression mapper)
                where TModule:IAutoMapperModule,new()
        {
            mapper.AddModule(new TModule());
        }
        public static void AddModule(this IMapperConfigurationExpression mapper, IAutoMapperModule module)
        {
            module.Configure(mapper);
        }
    }
}
