using AutoMapper;
using ECommerce.Billing.Repository.Entities;
using ECommerce.Global;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Billing.Repository.Repositories
{
    class InvoiceRepository : IInvoiceRepository
    {
        private readonly IMongoCollection<Invoice> collection;
        private readonly IMapper mapper;
        public InvoiceRepository(IMongoCollection<Invoice> collection, IMapper mapper)
        {
            this.collection = collection;
            this.mapper = mapper;
        }
        public async Task<Result<bool>> Create(Dto.Invoice invoice)
        {
            try
            {
                invoice.InvoiceDate = DateTime.Now;
                var item = mapper.Map<Invoice>(invoice);
                await collection.InsertOneAsync(item);
                return true;
            }
            catch (Exception exp)
            {

                return exp;
            }
        }
    }
}
