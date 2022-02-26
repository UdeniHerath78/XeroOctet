using Microsoft.Extensions.Logging;
using System;
using XeroOctet.Data.DBContext;
using XeroOctet.Data.Models;

namespace XeroOctet.DataAccess.Repositories
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository 
    {
        private readonly XeroDBContext _context;
        private readonly ILogger _logger;
        public InvoiceRepository(XeroDBContext context, ILogger logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

        public void Update(Invoice invoice)
        {
            try
            {
                _context.Invoice.Update(invoice);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Invoice Update function error", typeof(InvoiceRepository));
            }
            
        }
    }
}
