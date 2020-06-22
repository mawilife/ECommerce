using AutoMapper;
using ECommerce.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Billing.Api.Config
{
    public class AutoMapperProfile : Profile, IAutoMapperModule
    {
        public AutoMapperProfile()
        {
            this.CreateMap<Dto.InvoiceProduct, Models.InvoiceProductModel>();
            this.CreateMap< Models.InvoiceProductModel, Dto.InvoiceProduct>();
            this.CreateMap<Models.CreateModel, Dto.Invoice>();
            this.CreateMap<Dto.Invoice, Models.ResultModel>();
        }
        public void Configure(IMapperConfigurationExpression mapper)
        {

            mapper.AddModule< Service.Config.AutoMapperModule>();
            mapper.AddProfile(this);
        }
    }
}
