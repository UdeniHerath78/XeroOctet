using System.Collections.Generic;
using System.Threading.Tasks;
using XeroOctet.Data.Models;
using XeroOctet.WebClient.DTO;

namespace XeroOctet.WebClient.Services
{
    public interface IInvoiceService
    {
        Task<IEnumerable<InvoiceDTO>> getInvoices(); 
    }
}
