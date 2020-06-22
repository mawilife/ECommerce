using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Market.Repository.Entities
{
    class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("deleted")]
        public bool Deleted { get; set; }

        [BsonDateTimeOptions(Kind=DateTimeKind.Utc)]
        [BsonElement("creatation_date")]
        public DateTime CreationDate { get; set; }

        [BsonDateTimeOptions(Kind=DateTimeKind.Utc)]
        [BsonElement("modify_date")]
        public DateTime ModifyDate { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("code")]
        public string Code { get; set; }

        [BsonElement("price")]
        public decimal Price { get; set; }

        [BsonElement("stock_count")]
        public int StockCount { get; set; }
    }
}
