namespace Autumn.API.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Autumn.API.Models;

    public interface IBookService
    {
        Task<Book> GetAsync(long id);

        Task<Book> FindAsync(Expression<Func<Book, bool>> predicate);

        IQueryable<Book> FindAll(Expression<Func<Book, bool>> predicate);

        IQueryable<Book> GetAll();

        Task AddAsync(Book entity);

        void Delete(Book entity);

        void Edit(Book entity);
    }
}
