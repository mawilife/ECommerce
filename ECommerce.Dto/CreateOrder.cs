using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Dto
{
    public class CreateOrder
    {
        public PaymentMethod PaymentMethod { get; set; }
        public OrderedProductModel[] Products { get; set; }
    }
    public class OrderedProductModel
    {
        public string Code { get; set; }
        public int Amount { get; set; }
    }
   
}

