using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UOW_Models;

namespace UOW_Repository.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected ApplicationDBContext _context;
        protected DbSet<T> dbSet;
        protected readonly ILogger _logger;
        public Repository(ApplicationDBContext context,ILogger logger)
        {
            _context = context;
            _logger = logger;
          this.dbSet = context.Set<T>();
        }
        public virtual async Task<IEnumerable<T>> All()
        {
            return await dbSet.ToListAsync();
        }
        public virtual async Task<T> GetById(Guid id)
        {
            return await dbSet.FindAsync(id);
        }
        public virtual async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }
        public virtual Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }   
              
    }
}
