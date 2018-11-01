using Autumn.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Autumn.API.Services
{
    public interface IBookService
    {
        Task<Book> GetAsync(long id);

        Book Find(Expression<Func<Book, bool>> predicate);

        IQueryable<Book> FindAll(Expression<Func<Book, bool>> predicate);

        IQueryable<Book> GetAll();

        Task AddAsync(Book entity);

        void Delete(Book entity);

        void Edit(Book entity);
    }
}
