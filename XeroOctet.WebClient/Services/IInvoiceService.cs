using System.Collections.Generic;
using System.Threading.Tasks;
using Xero.NetStandard.OAuth2.Model.Accounting;
using XeroOctet.WebClient.DTO;

namespace XeroOctet.WebClient.Services
{
    public interface IInvoiceService
    {       
        Task<IEnumerable<Invoice>> getInvoices();
        Task<bool> saveInvoices(List<InvoiceDTO> invoiceDTOs);
    }
}
