using ECommerce.Global;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Market.Repository
{
    public interface IProductRepository
    {
        Task<Result<List<Dto.Product>>> ListAll();
        Task<Result<bool>> Insert(Dto.Product item);
        Task<Result<Dto.Product>> Get(string productCode);
        Task<Result<bool>> Delete(string productCode);
        Task<Result<bool>> Update(Dto.Product product);
        Task<Result<bool>> ChangeStock(string productCode, int changeAmount);
        Task<Result<List<Dto.Product>>> CheckAndDecraseStock(Dto.CreateOrder orderInfo);
        Task<Result<List<Dto.Product>>> ListProducts(string[] productCodes);
    }
}
