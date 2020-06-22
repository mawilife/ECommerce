using ECommerce.Dto;
using ECommerce.Global;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Market.Service
{
    public interface IInvoiceApiService
    {
        Task<Result<Invoice>> CreateInvoice (PaymentMethod method, InvoiceProduct[] products);
    }
}
