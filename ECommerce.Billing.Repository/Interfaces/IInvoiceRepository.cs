using ECommerce.Global;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Billing.Repository
{
    public interface IInvoiceRepository
    {
        Task<Result<bool>> Create(Dto.Invoice invoice);
    }
}
