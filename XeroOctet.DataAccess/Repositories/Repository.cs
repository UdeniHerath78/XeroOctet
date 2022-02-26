using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using XeroOctet.Data.DBContext;
using XeroOctet.DataAccess.Repositories.IRepositories;

namespace XeroOctet.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly XeroDBContext _db;
        internal DbSet<T> _dbSet; 
        public Repository(XeroDBContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }
        public async Task<List<T>> AddRangeAsync(IEnumerable<T> entity)
        {
            await _dbSet.AddRangeAsync(entity);
            return entity.ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            IQueryable<T> query = _dbSet;
            return await query.ToListAsync();
        }
        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = _dbSet;
            query = query.Where(filter);
            return await query.FirstOrDefaultAsync();
        }
    }
}
