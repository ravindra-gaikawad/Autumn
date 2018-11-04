namespace Autumn.WebApp.Services
{
    using Autumn.WebApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IBookService
    {
        Task<Book> GetAsync(long id);

        Task<Book> FindAsync(Expression<Func<Book, bool>> predicate);

        IQueryable<Book> FindAll(Expression<Func<Book, bool>> predicate);

        Task<IEnumerable<Book>> GetAllAsync();

        Task AddAsync(Book entity);

        void Delete(Book entity);

        void Edit(Book entity);
    }
}
