using AutoMapper;
using ECommerce.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Billing.Service.Config
{
    public class AutoMapperModule : IAutoMapperModule
    {
        public void Configure(IMapperConfigurationExpression mapper)
        {
            mapper.AddProfile<Repository.Config.AutoMapperProfile>();
        }
    }
}
