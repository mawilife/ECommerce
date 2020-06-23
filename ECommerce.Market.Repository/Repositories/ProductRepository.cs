using ECommerce.Market.Repository.Entities;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Global;
using AutoMapper;
using System.Linq;
namespace ECommerce.Market.Repository.Repositories
{
    class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> productCollection;
        private readonly IMapper mapper;
        public ProductRepository(IMongoCollection<Product> productCollection, IMapper mapper)
        {
            this.productCollection = productCollection;
            this.mapper = mapper;
        }

        public async Task<Result<bool>> Insert(Dto.Product product)
        {
            try
            {
                long count = await productCollection.Find(item => !item.Deleted && item.Code == product.Code).CountDocumentsAsync();
                if (count > 0)
                    return new Error("Duplicate Key");
                Product newItem = mapper.Map<Product>(product);
                newItem.ModifyDate = DateTime.Now;
                newItem.CreationDate = DateTime.Now;
                await productCollection.InsertOneAsync(newItem);
                return true;
            }
            catch (Exception exp)
            {
                return exp;
            }


        }
        public async Task<Result<List<Dto.Product>>> ListAll()
        {
            try
            {
                var result = await productCollection.Find(item => !item.Deleted).ToListAsync();
                return mapper.Map<List<Dto.Product>>(result);
            }
            catch (Exception exp)
            {
                return exp;
            }
        }
        public async Task<Result<Dto.Product>> Get(string productCode)
        {
            try
            {
                var result = await productCollection.Find(item => !item.Deleted && item.Code == productCode).FirstAsync();
                return mapper.Map<Dto.Product>(result);
            }
            catch (Exception exp)
            {
                return exp;
            }
        }
        public async Task<Result<bool>> Delete(string productCode)
        {
            try
            {
                var updateQuery = Builders<Product>.Update.Set(b => b.Deleted, true)
                                    .Set(b => b.ModifyDate, DateTime.Now);
                var filter = Builders<Product>.Filter.Eq(b => b.Code, productCode)
                             & Builders<Product>.Filter.Eq(b => b.Deleted, false);
                var result = await productCollection.UpdateOneAsync(filter, updateQuery);
                return result.ModifiedCount > 0;
            }
            catch (Exception exp)
            {
                return exp;
            }
        }
        public async Task<Result<bool>> Update(Dto.Product product)
        {
            try
            {
                var updateQuery = Builders<Product>.Update.Set(b => b.Name, product.Name)
                                    .Set(b => b.Price, product.Price)
                                    .Set(b => b.ModifyDate, DateTime.Now);
                var filter = Builders<Product>.Filter.Eq(b => b.Code, product.Code)
                             & Builders<Product>.Filter.Eq(b => b.Deleted, false);
                var result = await productCollection.UpdateOneAsync(filter, updateQuery);
                return result.ModifiedCount > 0;
            }
            catch (Exception exp)
            {
                return exp;
            }
        }
        public async Task<Result<bool>> ChangeStock(string productCode, int changeAmount)
        {
            try
            {
                var filter = Builders<Product>.Filter.Eq(b => b.Code, productCode)
                        & Builders<Product>.Filter.Eq(b => b.Deleted, false)
                        & Builders<Product>.Filter.Gte(b => b.StockCount, -changeAmount);
                var updateQuery = Builders<Product>.Update.Inc(b => b.StockCount, changeAmount);
                var result = await productCollection.UpdateOneAsync(filter, updateQuery);
                return result.ModifiedCount > 0;

            }
            catch (Exception exp)
            {

                return exp;
            }

        }
        public async Task<Result<List<Dto.Product>>> CheckAndDecraseStock(Dto.CreateOrder orderInfo)
        {
            try
            {
                List<Dto.OrderedProductModel> completedModels = new List<Dto.OrderedProductModel>();
                bool isSuccess = true;
                List<string> codes = new List<string>();
                foreach (var p in orderInfo.Products)
                {
                    isSuccess = (await this.ChangeStock(p.Code, -p.Amount)).Success;
                    if (!isSuccess)
                        break;
                    completedModels.Add(p);
                    codes.Add(p.Code);
                }
                if (!isSuccess)
                {
                    try
                    {
                        foreach (var p in completedModels)
                        {
                            await this.ChangeStock(p.Code, p.Amount);
                        }
                    }
                    catch (Exception ex)
                    {
                        /// we able to create special notification for not updated amounts
                    }
                    return Error.NotFound;
                }
                return await this.ListProducts(codes.ToArray());
            }
            catch (Exception exp)
            {

                return exp;
            }


        }
        public async Task<Result<List<Dto.Product>>> ListProducts(string[] productCodes)
        {
            try
            {
                var filter = Builders<Product>.Filter.In(b => b.Code, productCodes)
                            & Builders<Product>.Filter.Eq(b => b.Deleted, false); ;
                var result = await this.productCollection.Find(filter).ToListAsync();
                return this.mapper.Map<List<Dto.Product>>(result);
            }
            catch (Exception exp)
            {
                return exp;
            }

        }
    }
}
