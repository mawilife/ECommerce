using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Dto
{
    public enum PaymentMethod
    {
        CreditCard = 1,
        Cash = 2
    }
    public class Invoice
    {
        public DateTime InvoiceDate { get; set; }
        public InvoiceProduct[] Products { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public Decimal TotalSum { get; set; }
    }
}
