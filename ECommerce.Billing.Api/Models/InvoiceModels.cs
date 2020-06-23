using ECommerce.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Billing.Api.Models
{
    /// <summary>
    /// Payment Method:1 for CreditCard 2 for Cash
    /// </summary>
    public enum PaymentMethods
    {
        CreditCard = 1,
        Cash = 2
    }
    /// <summary>
    /// 
    /// </summary>
    public class InvoiceProductModel
    {
        /// <summary>
        /// Name of Product
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Code of Product
        /// </summary>
        [Required]
        public string Code { get; set; }
        /// <summary>
        /// Price of Each Product
        /// </summary>
        [Required]
        public decimal Price { get; set; }
        /// <summary>
        /// Amount  of Ordered Product
        /// </summary>
        [Required]
        [Range(1, int.MaxValue)]
        public int Amount { get; set; }
    }
    /// <summary>
    /// For creation of Invoice
    /// </summary>
    public class CreateModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [MinLength(1)]
        public InvoiceProductModel[] Products { get; set; }
        /// <summary>
        ///  Payment Method:1 for CreditCard 2 for Cash
        /// </summary>
        [Required]
        [Range(1,2)]
        public PaymentMethods PaymentMethod { get; set; }
    }
    /// <summary>
    /// Result of createInvoice function
    /// </summary>
    public class ResultModel
    {
        // <summary>
        ///  Invoice creation date
        /// </summary>
        [Required]
        public DateTime InvoiceDate { get; set; }
        // <summary>
        ///  
        /// </summary>
        [Required]
        public InvoiceProductModel[] Products { get; set; }
        // <summary>
        ///  Payment Method:1 for CreditCard 2 for Cash
        /// </summary>
        [Required]
        [Range(1, 2)]
        public PaymentMethods PaymentMethod { get; set; }
        // <summary>
        ///  Total cost of order
        /// </summary>
        [Required]
        public Decimal TotalSum { get; set; }
    }
}
