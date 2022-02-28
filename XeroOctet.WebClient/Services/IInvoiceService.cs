using System.Collections.Generic;
using System.Threading.Tasks;
using XeroOctet.Shared.DTO;

namespace XeroOctet.WebClient.Services
{
    public interface IInvoiceService
    {
        Task<IEnumerable<InvoiceDTO>> GetInvoices();
        Task<bool> SaveInvoices(IEnumerable<InvoiceDTO> invoiceDTOs);
    }
}
