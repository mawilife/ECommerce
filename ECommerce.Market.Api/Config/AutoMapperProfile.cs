using AutoMapper;
using ECommerce.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Market.Api.Config
{
    public class AutoMapperProfile : Profile, IAutoMapperModule
    {
        public AutoMapperProfile()
        {
            this.CreateMap<Models.ProductUpdateModel, Dto.Product>();
            this.CreateMap<Models.OrderedProductModel, Dto.OrderedProductModel>();
            this.CreateMap<Models.OrderModel, Dto.CreateOrder>();
        }
        public void Configure(IMapperConfigurationExpression mapper)
        {
            mapper.AddModule< Service.Config.AutoMapperModule>();
            mapper.AddProfile(this);
        }
    }
}
