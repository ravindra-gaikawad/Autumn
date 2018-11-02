namespace Autumn.API.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Autumn.API.Models;

    public interface IWishService
    {
        Task<Wish> GetAsync(long id);

        Task<Wish> FindAsync(Expression<Func<Wish, bool>> predicate);

        IQueryable<Wish> FindAll(Expression<Func<Wish, bool>> predicate);

        IQueryable<Wish> GetAll();

        Task AddAsync(Wish entity);

        void Delete(Wish entity);

        void Edit(Wish entity);
    }
}
