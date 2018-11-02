namespace Autumn.API.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Autumn.API.Models;
    using Autumn.API.Repository;

    public class BookPageService : IBookPageService
    {
        private readonly IRepository repository;

        public BookPageService(IRepository repository)
        {
            this.repository = repository;
        }

        async Task IBookPageService.AddAsync(BookPage entity)
        {
            await this.repository.AddAsync(entity);
        }

        void IBookPageService.Delete(BookPage entity)
        {
            this.repository.Delete(entity);
        }

        void IBookPageService.Edit(BookPage entity)
        {
            this.repository.Edit(entity);
        }

        async Task<BookPage> IBookPageService.FindAsync(Expression<Func<BookPage, bool>> predicate)
        {
            return await this.repository.FindAsync(predicate);
        }

        IQueryable<BookPage> IBookPageService.FindAll(Expression<Func<BookPage, bool>> predicate)
        {
            return this.repository.FindAll(predicate);
        }

        async Task<IQueryable<BookPage>> IBookPageService.GetAllAsync(long bookId)
        {
            var book = await this.repository.GetAsync<Book>(bookId);

            if (book == null)
            {
                return null;
            }

            return this.repository.FindAll<BookPage>(p => p.BookId == bookId);
        }

        async Task<BookPage> IBookPageService.GetAsync(long bookId, long id)
        {
            var book = await this.repository.GetAsync<Book>(bookId);

            if (book == null)
            {
                return null;
            }

            return await this.repository.GetAsync<BookPage>(id);
        }
    }
}
