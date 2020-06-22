using ECommerce.Dto;
using ECommerce.Global;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Market.Service
{
    public interface IProductService
    {
        Task<Result<List<Dto.Product>>> ListAll();
        Task<Result<bool>> Insert(Dto.Product item);
        Task<Result<Dto.Product>> Get(string productCode);
        Task<Result<bool>> Delete(string productCode);
        Task<Result<bool>> Update(Dto.Product product);
        Task<Result<bool>> ChangeStock(string productCode, int changeAmount);
        Task<Result<Invoice>> Order(CreateOrder orderInfo);
    }
}
