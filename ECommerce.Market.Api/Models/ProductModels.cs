using ECommerce.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Market.Api.Models
{
    /// <summary>
    /// test
    /// </summary>
    public class ProductCodeModel
    {
        /// <summary>
        /// Product Code for operation.
        /// </summary>
        [Required]
        [MinLength(3)]
        [MaxLength(32)]
        public string Code { get; set; }
    }
   
    /// <summary>
    /// 
    /// </summary>
    public class ProductUpdateModel
    {
        /// <summary>
        /// New name for update
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Uniqe Product code for selectin product for update
        /// </summary>
        [Required]
        public string Code { get; set; }
        /// <summary>
        /// New Price
        /// </summary>
        [Required]
        public decimal Price { get; set; }
    }

    public class ProductStockChangeModel
    {
        public string Code { get; set; }
        public int ChangeAmount { get; set; }
    }
    public class OrderedProductModel
    {
        public string Code { get; set; }
        public int Amount { get; set; }
    }
    public enum PaymentMethods
    {
        CreditCard = 1,
        Cash = 2
    }
    public class OrderModel
    {
        public PaymentMethods PaymentMethod { get; set; }
        public OrderedProductModel[] Products { get; set; }

    }
}
