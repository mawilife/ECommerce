using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Dto
{
    public class InvoiceProduct
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
    }
}
