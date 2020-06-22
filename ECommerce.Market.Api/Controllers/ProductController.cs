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
    [ApiController]
    [Route("api")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService service;
        private readonly IMapper mapper;
        private readonly ILogger<ProductController> logger;

        public ProductController(ILogger<ProductController> logger, IProductService service,IMapper mapper)
        {
            this.logger = logger;
            this.service = service;
            this.mapper = mapper;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Perfecto</response>
        /// <response code="500">Error</response>
        [HttpGet]
        public async Task<ActionResult<List<Dto.Product>>> Get()
        {
            return this.ToActionResult(await service.ListAll(), logger);
        }
        
        [HttpPost("Get")]
        public async Task<ActionResult<Dto.Product>> Get([FromBody] ProductCodeModel model)
        {
            return this.ToActionResult(await service.Get(model.Code), logger);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] ProductCodeModel model)
        {
            return this.ToActionResult(await service.Delete(model.Code), logger);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Dto.Product product)
        {
            return this.ToActionResult(await this.service.Insert(product), logger);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] ProductUpdateModel model)
        {
            return this.ToActionResult(await this.service.Update(mapper.Map<Dto.Product>(model)),logger);
        }
        [HttpPost("UpdateStock")]
        public async Task<IActionResult> UpdateStock([FromBody] ProductStockChangeModel model)
        {
            return this.ToActionResult(await this.service.ChangeStock(model.Code,model.ChangeAmount), logger);
        }
        [HttpPost("Order")]
        public async Task<ActionResult<Dto.Invoice>> Order([FromBody] OrderModel model)
        {
            var orderInfo = mapper.Map < Dto.CreateOrder > (model);
            return this.ToActionResult(await this.service.Order(orderInfo), logger);
        }

    }
}
