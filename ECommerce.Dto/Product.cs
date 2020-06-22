using System;

namespace ECommerce.Dto
{
    public class Product
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public int StockCount { get; set; }
    }
}
