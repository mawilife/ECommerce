using ECommerce.Dto;
using ECommerce.Global;
using ECommerce.Market.Service.Config;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
namespace ECommerce.Market.Service.Services
{
    class InvoiceApiService : IInvoiceApiService
    {
        public readonly IInvoiceConnectionConfig connectionConfig;
        public InvoiceApiService(IInvoiceConnectionConfig connectionConfig)
        {
            this.connectionConfig = connectionConfig;
        }
        public async Task<Result<Invoice>> CreateInvoice(PaymentMethod method, InvoiceProduct[] products)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var contentString = JsonSerializer.Serialize(new
                    {
                        paymentMethod=method,
                        products
                    });
                    var content = new StringContent(contentString, Encoding.UTF8, "application/json");
                    var result = await client.PutAsync(this.connectionConfig.Endpoint, content);
                    var resultContent = await result.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    if (result.IsSuccessStatusCode)
                        return JsonSerializer.Deserialize<Invoice>(resultContent,options);
                    return new Error(resultContent);
                }
                catch (Exception exp)
                {
                    return exp;
                }
                
            }
           
        }
    }
}
