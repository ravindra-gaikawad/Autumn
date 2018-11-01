using Autumn.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Autumn.API.Services
{
    public interface IBookPageService
    {
        Task<BookPage> GetAsync(long id);

        BookPage Find(Expression<Func<BookPage, bool>> predicate);

        IQueryable<BookPage> FindAll(Expression<Func<BookPage, bool>> predicate);

        IQueryable<BookPage> GetAll();

        Task AddAsync(BookPage entity);

        void Delete(BookPage entity);

        void Edit(BookPage entity);
    }
}
