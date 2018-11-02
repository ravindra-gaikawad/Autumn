namespace Autumn.API.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Autumn.API.Models;

    public interface IBookPageService
    {
        Task<BookPage> GetAsync(long id);

        Task<BookPage> FindAsync(Expression<Func<BookPage, bool>> predicate);

        IQueryable<BookPage> FindAll(Expression<Func<BookPage, bool>> predicate);

        IQueryable<BookPage> GetAll();

        Task AddAsync(BookPage entity);

        void Delete(BookPage entity);

        void Edit(BookPage entity);
    }
}
