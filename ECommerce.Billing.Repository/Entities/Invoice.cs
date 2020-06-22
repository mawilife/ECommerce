using ECommerce.Dto;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Billing.Repository.Entities
{
    
    class Invoice
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        [BsonElement("date")]
        public DateTime InvoiceDate { get; set; }

        [BsonElement("products")]
        public InvoiceProduct[] Products { get; set; }

        [BsonElement("payment_method")]
        public PaymentMethod PaymentMethod { get; set; }

        [BsonElement("total_sum")]
        public Decimal TotalSum { get; set; }
    }
}
