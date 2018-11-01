using Autumn.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Autumn.API.Repository
{
    public interface IRepository
    {
        Task<T> GetAsync<T>(long id)
            where T : BaseEntity;

        IQueryable<T> GetAll<T>()
            where T : BaseEntity;

        T Find<T>(Expression<Func<T, bool>> predicate)
            where T : BaseEntity;

        IQueryable<T> FindAll<T>(Expression<Func<T, bool>> predicate)
            where T : BaseEntity;

        void AddAsync<T>(T entity)
            where T : BaseEntity;

        void Delete<T>(T entity)
            where T : BaseEntity;

        void Edit<T>(T entity)
            where T : BaseEntity;
    }
}
