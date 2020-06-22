using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Billing.Repository.Entities
{
    class InvoiceProduct
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("code")]
        public string Code { get; set; }

        [BsonElement("price")]
        public decimal Price { get; set; }
    }
}
