using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xero.NetStandard.OAuth2.Model.Accounting;
using XeroOctet.Shared.DTO;

namespace XeroOctet.Api.Services
{
    public class XeroInvoiceApiService : IXeroInvoiceApiService
    {
        public async Task<IEnumerable<InvoiceDTO>> GetFilteredInvoiceData(IEnumerable<Invoice> invoices)
        {
            IEnumerable<InvoiceDTO> invoiceDataFiltered = (from p in invoices
                                       group p by p.Contact.Name into invoiceGroup
                                       select new InvoiceDTO                                   {
                                           ContactName = invoiceGroup.Key,
                                           InvoiceAmount = invoiceGroup.Sum(x => x.Total),
                                           InvoiceNumber = invoiceGroup.Select(c => c.InvoiceNumber).FirstOrDefault(),
                                           InvoiceIssueDate = invoiceGroup.Select(c => c.Date).FirstOrDefault(),
                                           OutstandingAmount = invoiceGroup.Select(c => c.AmountDue).FirstOrDefault(),
                                       }).Where(c => c.InvoiceNumber != "" && c.OutstandingAmount > 0).ToList().Take(20);

            return invoiceDataFiltered;
        }

        
    }
}
