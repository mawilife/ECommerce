using ECommerce.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Billing.Api.Models
{
    
    public enum PaymentMethods
    {
        CreditCard = 1,
        Cash = 2
    }
    public class InvoiceProductModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
    }
    public class CreateModel
    {
        public InvoiceProductModel[] Products { get; set; }
        public PaymentMethods PaymentMethod { get; set; }
    }
    public class ResultModel
    {
        public DateTime InvoiceDate { get; set; }
        public InvoiceProductModel[] Products { get; set; }
        public PaymentMethods PaymentMethod { get; set; }
        public Decimal TotalSum { get; set; }
    }
}
