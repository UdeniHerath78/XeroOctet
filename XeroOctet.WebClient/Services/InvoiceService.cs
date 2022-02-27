using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xero.NetStandard.OAuth2.Model.Accounting;
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

        public async Task<IEnumerable<Invoice>> getInvoices()
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "/XeroInvoiceData");
            var responseResult = await _httpClient.SendAsync(requestMessage);

            if (responseResult.StatusCode == HttpStatusCode.OK)
            {
                var result = await responseResult.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Invoice>>(result);
            }

            return null;
        }

        public async Task<bool> saveInvoices(List<InvoiceDTO> invoiceDTOs)
        {
            string json = JsonConvert.SerializeObject(invoiceDTOs);

            StringContent data = new StringContent(json, Encoding.UTF8, "application/json");

            var responseResult = await _httpClient.PostAsync("/XeroInvoiceData/SaveInvoice", data);

            if (responseResult.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }

            return false;

        }
    }
}
