namespace Autumn.API.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Autumn.API.Models;

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

        Task AddAsync<T>(T entity)
            where T : BaseEntity;

        void Delete<T>(T entity)
            where T : BaseEntity;

        void Edit<T>(T entity)
            where T : BaseEntity;
    }
}
