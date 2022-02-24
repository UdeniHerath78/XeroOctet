using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XeroOctet.Data.DBContext;

namespace XeroOctet.Data.Repositories
{
    public class InvoiceRepository<T> : IInvoiceRepository<T> where T : class
    {

        protected XeroDBContext _context;
        internal DbSet<T> _dbSet;
        protected readonly ILogger _logger;

        public InvoiceRepository(XeroDBContext context, ILogger logger)
        {
            _context = context;
            _dbSet = context.Set<T>();
            _logger = logger;

        }
        public async Task<bool> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public async Task<IEnumerable<T>> All()
        {
            return await _dbSet.ToListAsync();
        }

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetById(string id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
