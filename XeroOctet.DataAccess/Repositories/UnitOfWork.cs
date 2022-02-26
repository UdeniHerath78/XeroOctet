using Microsoft.Extensions.Logging;
using System;
using XeroOctet.Data.DBContext;
using XeroOctet.DataAccess.Repositories.IRepositories;

namespace XeroOctet.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IInvoiceRepository Invoice {get; private set;}

        private readonly XeroDBContext _context;
        private readonly ILogger<UnitOfWork> _logger;

        public UnitOfWork(XeroDBContext context, ILogger<UnitOfWork> logger)
        {
            _context = context;
            _logger = logger;
            Invoice = new InvoiceRepository(_context, _logger);
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Save function error", typeof(UnitOfWork));
            }
        }
    }
}
