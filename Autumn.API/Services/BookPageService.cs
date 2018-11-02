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

        IQueryable<BookPage> IBookPageService.GetAll()
        {
            return this.repository.GetAll<BookPage>();
        }

        async Task<BookPage> IBookPageService.GetAsync(long id)
        {
            return await this.repository.GetAsync<BookPage>(id);
        }
    }
}
