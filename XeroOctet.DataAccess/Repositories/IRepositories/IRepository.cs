using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace XeroOctet.DataAccess.Repositories.IRepositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<List<T>> AddRangeAsync(IEnumerable<T> entity);

    }
}
