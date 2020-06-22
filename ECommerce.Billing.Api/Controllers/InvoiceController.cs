using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Billing.Api.Models;
using ECommerce.Billing.Service;
using ECommerce.Global;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ECommerce.Billing.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
       
        private readonly ILogger<InvoiceController> logger;
        private readonly IInvoiceService service;
        private readonly IMapper mapper;

        public InvoiceController(ILogger<InvoiceController> logger,IInvoiceService service, IMapper mapper)
        {
            this.logger = logger;
            this.service = service;
            this.mapper = mapper;
        }

        [HttpPut]
        public async Task<ActionResult<ResultModel>> Create(CreateModel invoice)
        {
            var item = mapper.Map<Dto.Invoice>(invoice);
            item.TotalSum = item.Products.Sum(p => p.Price*p.Amount);
            var result = await this.service.Create(item);
            var resultItem = mapper.Map<ResultModel>(item);
            return this.ToActionResult(result.Success?
                (Result<ResultModel>)resultItem:result.ToError<ResultModel>(), logger);
        }
    }
}
