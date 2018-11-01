using Autumn.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Autumn.API.Services
{
    public interface IWishService
    {
        Task<Wish> GetAsync(long id);

        Wish Find(Expression<Func<Wish, bool>> predicate);

        IQueryable<Wish> FindAll(Expression<Func<Wish, bool>> predicate);

        IQueryable<Wish> GetAll();

        Task AddAsync(Wish entity);

        void Delete(Wish entity);

        void Edit(Wish entity);
    }
}
