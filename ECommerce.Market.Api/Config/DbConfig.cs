using ECommerce.Data.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Market.Api.Config
{
    public class DbConfig : IDatabaseConfig
    {
        public DbConfig(IConfigurationRoot root)
        {
            var section = root.GetSection("DatabaseSettings");
            this.ConnectionString = section["ConnectionString"];
            this.DatabaseName= section["Database"];
            this.Table = section["Table"];
        }

        public string ConnectionString {get;}

        public string DatabaseName { get; }
        public string Table { get; }
    }
}
