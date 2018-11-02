namespace Autumn.API.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Autumn.API.Models;
    using Autumn.API.Repository;

    public class WishService : IWishService
    {
        private readonly IRepository repository;

        public WishService(IRepository repository)
        {
            this.repository = repository;
        }

        async Task IWishService.AddAsync(Wish entity)
        {
            await this.repository.AddAsync(entity);
        }

        void IWishService.Delete(Wish entity)
        {
            this.repository.Delete(entity);
        }

        void IWishService.Edit(Wish entity)
        {
            this.repository.Edit(entity);
        }

        Wish IWishService.Find(Expression<Func<Wish, bool>> predicate)
        {
            return this.repository.Find(predicate);
        }

        IQueryable<Wish> IWishService.FindAll(Expression<Func<Wish, bool>> predicate)
        {
            return this.repository.FindAll(predicate);
        }

        IQueryable<Wish> IWishService.GetAll()
        {
            return this.repository.GetAll<Wish>();
        }

        async Task<Wish> IWishService.GetAsync(long id)
        {
            return await this.repository.GetAsync<Wish>(id);
        }
    }
}
