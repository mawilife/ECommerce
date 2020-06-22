using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Billing.Repository.Config
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<Entities.InvoiceProduct, Dto.InvoiceProduct>();
            this.CreateMap<Dto.InvoiceProduct, Entities.InvoiceProduct>();
            this.CreateMap<Entities.Invoice, Dto.Invoice>();
            this.CreateMap<Dto.Invoice, Entities.Invoice>();

        }
    }
}
