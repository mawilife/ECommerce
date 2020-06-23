using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Market.Api.Models;
using ECommerce.Market.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace ECommerce.Market.Api.Controllers
{
    /// <summary>
    /// List ,Get,Update,Delete,Insert,ChangeStock,Order Products
    /// </summary>
    [ApiController]
    [Route("api")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService service;
        private readonly IMapper mapper;
        private readonly ILogger<ProductController> logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="service">ProductService</param>
        /// <param name="mapper">IMapper from AutoMapper</param>
        public ProductController(ILogger<ProductController> logger, IProductService service,IMapper mapper)
        {
            this.logger = logger;
            this.service = service;
            this.mapper = mapper;
        }
        /// <summary>
        /// For listing all Products.
        /// </summary>
        /// <returns>ProductList</returns>
        [HttpGet]
        public async Task<ActionResult<List<Dto.Product>>> Get()
        {
            return this.ToActionResult(await service.ListAll(), logger);
        }
        /// <summary>
        /// For getiing single Product.Uses ProductCodeModel for parameter.
        /// </summary>
        /// <param name="model">ProductCodeModel</param>
        /// <returns>Single Product</returns>
        [HttpPost("Get")]
        public async Task<ActionResult<Dto.Product>> Get([FromBody] ProductCodeModel model)
        {
            return this.ToActionResult(await service.Get(model.Code), logger);
        }
        /// <summary>
        /// For deleting single Product.Uses ProductCodeModel for parameter.
        /// </summary>
        /// <param name="model">ProductCodeModel</param>
        /// <returns>Boolean</returns>
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] ProductCodeModel model)
        {
            return this.ToActionResult(await service.Delete(model.Code), logger);
        }
        /// <summary>
        /// For inserting Product.Uses ProductModel for parameter.
        /// </summary>
        /// <param name="product">ProductModel</param>
        /// <returns>Boolean</returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductModel product)
        {
            var item = this.mapper.Map<Dto.Product>(product);
            return this.ToActionResult(await this.service.Insert(item), logger);
        }
        /// <summary>
        /// For updating Product.Uses ProductUpdateModel for parameter.
        /// </summary>
        /// <param name="model">ProductUpdateModel</param>
        /// <returns>Boolean</returns>
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] ProductUpdateModel model)
        {
            return this.ToActionResult(await this.service.Update(mapper.Map<Dto.Product>(model)),logger);
        }
        /// <summary>
        /// For changing Product stock.Uses ProductStockChangeModel for parameter.
        /// </summary>
        /// <param name="model">ProductStockChangeModel</param>
        /// <returns>Boolean</returns>
        [HttpPost("UpdateStock")]
        public async Task<IActionResult> UpdateStock([FromBody] ProductStockChangeModel model)
        {
            return this.ToActionResult(await this.service.ChangeStock(model.Code,model.ChangeAmount), logger);
        }
        /// <summary>
        /// For ordering product and getting invoice.Uses OrderModel for parameter.returns Invoice
        /// </summary>
        /// <param name="model">OrderModel</param>
        /// <returns>Invoice</returns>
        [HttpPost("Order")]
        public async Task<ActionResult<Dto.Invoice>> Order([FromBody] OrderModel model)
        {
            var orderInfo = mapper.Map < Dto.CreateOrder > (model);
            return this.ToActionResult(await this.service.Order(orderInfo), logger);
        }

    }
}
