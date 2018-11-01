using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Autumn.API.Repository
{
    public class AutumnDBContextRepository : IRepository
    {
        private readonly DbContext dbContext;

        public AutumnDBContextRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        async Task IRepository.AddAsync<T>(T entity)
        {
            await this.dbContext.Set<T>().AddAsync(entity);
        }

        void IRepository.Delete<T>(T entity)
        {
            this.dbContext.Set<T>().Remove(entity);
        }

        void IRepository.Edit<T>(T entity)
        {
            this.dbContext.Set<T>().Update(entity);
        }

        IQueryable<T> IRepository.FindAll<T>(Expression<Func<T, bool>> predicate)
        {
            return this.dbContext.Set<T>().AsQueryable().Where(predicate);
        }

        async Task<T> IRepository.GetAsync<T>(long id)
        {
            return await this.dbContext.Set<T>().FindAsync(id);
        }

        IQueryable<T> IRepository.GetAll<T>()
        {
            return this.dbContext.Set<T>().AsQueryable();
        }

        T IRepository.Find<T>(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
