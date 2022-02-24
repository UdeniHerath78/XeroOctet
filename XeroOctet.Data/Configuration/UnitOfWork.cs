using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using XeroOctet.Data.DBContext;
using XeroOctet.Data.Models;
using XeroOctet.Data.Repositories;

namespace XeroOctet.Data.Configuration
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public IInvoiceRepository<Invoice> Invoice {get; private set;}

        private readonly XeroDBContext _context;
        private readonly ILogger _logger;

        public UnitOfWork(XeroDBContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");
            Invoice = new InvoiceRepository<Invoice>(context, _logger);
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
