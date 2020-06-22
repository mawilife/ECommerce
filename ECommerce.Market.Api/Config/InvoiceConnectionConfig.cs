using ECommerce.Market.Service.Config;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Market.Api.Config
{
    public class InvoiceConnectionConfig : IInvoiceConnectionConfig
    {
        public InvoiceConnectionConfig(IConfigurationRoot configRoot)
        {
            var section=configRoot.GetSection("InvoiceSettings");
            this.Endpoint = section["Endpoint"];
        }
        public string Endpoint  { get;}
    }
}
