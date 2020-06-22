using ECommerce.Global;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Billing.Service
{
    public interface IInvoiceService
    {
        Task<Result<bool>> Create(Dto.Invoice invoice);
    }
}
