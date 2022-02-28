using System.Collections.Generic;
using System.Threading.Tasks;
using Xero.NetStandard.OAuth2.Model.Accounting;
using XeroOctet.Shared.DTO;

namespace XeroOctet.Api.Services
{
    public interface IXeroInvoiceApiService
    {
        Task<IEnumerable<InvoiceDTO>> GetFilteredInvoiceData(IEnumerable<Invoice> invoices);
    }
}
