namespace Autumn.API.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

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
            return this.dbContext.Set<T>().AsNoTracking().Where(predicate);
        }

        async Task<T> IRepository.GetAsync<T>(long id)
        {
            return await this.dbContext.Set<T>().AsNoTracking().Where(e => e.Id == id).FirstAsync();
        }

        IQueryable<T> IRepository.GetAll<T>()
        {
            return this.dbContext.Set<T>().AsNoTracking();
        }

        async Task<T> IRepository.FindAsync<T>(Expression<Func<T, bool>> predicate)
        {
            return await this.dbContext.Set<T>().AsNoTracking().Where(predicate).FirstAsync();
        }
    }
}
