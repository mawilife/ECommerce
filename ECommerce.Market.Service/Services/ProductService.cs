using ECommerce.Dto;
using ECommerce.Global;
using ECommerce.Market.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;

namespace ECommerce.Market.Service.Services
{
    class ProductService : IProductService
    {
        private readonly IProductRepository repository;
        private readonly IInvoiceApiService invoiceService;
        private readonly IMapper mapper;
        public ProductService(IProductRepository repository, IInvoiceApiService invoiceService, IMapper mapper)
        {
            this.repository = repository;
            this.invoiceService = invoiceService;
            this.mapper = mapper;
        }

        public async Task<Result<bool>> Delete(string productCode)
        {
            return await repository.Delete(productCode);
        }

        public async Task<Result<Product>> Get(string productCode)
        {
            return await repository.Get(productCode);
        }

        public async Task<Result<bool>> Insert(Dto.Product product)
        {
            return await this.repository.Insert(product);
        }
        public async Task<Result<List<Dto.Product>>> ListAll()
        {
            return await this.repository.ListAll();
        }
        public async Task<Result<bool>> Update(Dto.Product product)
        {
            return await this.repository.Update(product);
        }
        public async Task<Result<bool>> ChangeStock(string productCode, int changeAmount)
        {
            return await this.repository.ChangeStock(productCode, changeAmount);
        }

        private InvoiceProduct Map(Product product, OrderedProductModel order)
        {
            var result = mapper.Map<InvoiceProduct>(product);
            result.Amount = order.Amount;
            return result;
        }
        public async Task<Result<Invoice>> Order(CreateOrder orderInfo)
        {
            var productResult = await this.repository.CheckAndDecraseStock(orderInfo);
            if (!productResult)
                return productResult.ToError<Invoice>();


            var result = (from product in productResult.Data
                          join order in orderInfo.Products on product.Code equals order.Code
                          select Map(product, order)).ToArray();
            return await this.invoiceService.CreateInvoice(orderInfo.PaymentMethod, result);


        }
    }
}
