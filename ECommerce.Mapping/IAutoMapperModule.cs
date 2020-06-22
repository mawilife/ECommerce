using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Mapping
{
    public interface IAutoMapperModule
    {
        void Configure(IMapperConfigurationExpression mapper);
    }
}
