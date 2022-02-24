using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace XeroOctet.Data.Repositories
{
    public interface IInvoiceRepository<T> where T : class
    {
        Task<IEnumerable<T>> All();
        Task<T> GetById(string id);
        Task<bool> Add(T entity);
        Task<bool> Delete(string id);
    }
}
