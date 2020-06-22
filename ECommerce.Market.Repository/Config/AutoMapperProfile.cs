using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Market.Repository.Config
{
    public class AutoMapperProfile:AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<Entities.Product, Dto.Product>();
            this.CreateMap<Dto.Product, Entities.Product>();

        }
    }
}
