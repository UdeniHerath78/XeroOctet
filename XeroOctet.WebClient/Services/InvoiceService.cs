using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using XeroOctet.Data.Models;
using XeroOctet.WebClient.DTO;

namespace XeroOctet.WebClient.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly HttpClient _httpClient;

        public InvoiceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<InvoiceDTO>> getInvoices()
        {
            return await _httpClient.GetJsonAsync<InvoiceDTO[]>("invoice/");
        }
    }
}
