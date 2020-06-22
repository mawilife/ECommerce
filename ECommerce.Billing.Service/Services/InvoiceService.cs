using ECommerce.Dto;
using ECommerce.Global;
using ECommerce.Billing.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Billing.Service.Services
{
    class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository repository;
        public InvoiceService(IInvoiceRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Result<bool>> Create(Invoice invoice)
        {
            return await this.repository.Create(invoice);
        }
    }
}
