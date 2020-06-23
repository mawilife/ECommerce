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
    /// <summary>
    /// 
    /// </summary>
    public class ProductStockChangeModel
    {
        /// <summary>
        /// Target product code
        /// </summary>
        [Required]
        public string Code { get; set; }
        /// <summary>
        /// ChangeAmaunt:negative for decresing, positive for increasing
        /// </summary>
        [Required]
        public int ChangeAmount { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class OrderedProductModel
    {
        /// <summary>
        /// Code of Ordered item 
        /// </summary>
        [Required]
        public string Code { get; set; }
        /// <summary>
        /// Ordered item quantity
        /// </summary>
        [Required]
        [Range(1, int.MaxValue)]
        public int Amount { get; set; }
    }
    /// <summary>
    ///  Payment Method:1 for CreditCard 2 for Cash
    /// </summary>
    public enum PaymentMethods
    {
        CreditCard = 1,
        Cash = 2
    }
    /// <summary>
    /// 
    /// </summary>
    public class OrderModel
    {
        [Required]
        [Range(1, 2)]
        public PaymentMethods PaymentMethod { get; set; }
        [Required]
        [MinLength(1)]
        public OrderedProductModel[] Products { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class ProductModel
    {
        /// <summary>
        /// Name of Product
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Uniqe Product Code
        /// </summary>
        [Required]
        public string Code { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        [Required]
        [Range(0, Double.MaxValue)]
        public decimal Price { get; set; }
        /// <summary>
        /// StockCount
        /// </summary>
        [Required]
        [Range(0, int.MaxValue)]
        public int StockCount { get; set; }
    }
}
