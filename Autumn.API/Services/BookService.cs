namespace Autumn.API.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Autumn.API.Models;
    using Autumn.API.Repository;

    public class BookService : IBookService
    {
        private readonly IRepository repository;

        public BookService(IRepository repository)
        {
            this.repository = repository;
        }

        async Task IBookService.AddAsync(Book entity)
        {
            await this.repository.AddAsync(entity);
        }

        void IBookService.Delete(Book entity)
        {
            this.repository.Delete(entity);
        }

        void IBookService.Edit(Book entity)
        {
            this.repository.Edit(entity);
        }

        async Task<Book> IBookService.FindAsync(Expression<Func<Book, bool>> predicate)
        {
            return await this.repository.FindAsync(predicate);
        }

        IQueryable<Book> IBookService.FindAll(Expression<Func<Book, bool>> predicate)
        {
            return this.repository.FindAll(predicate);
        }

        async Task<Book> IBookService.GetAsync(long id)
        {
            return await this.repository.GetAsync<Book>(id);
        }

        IQueryable<Book> IBookService.GetAll()
        {
            return this.repository.GetAll<Book>();
        }
    }
}
