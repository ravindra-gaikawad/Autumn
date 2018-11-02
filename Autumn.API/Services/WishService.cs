namespace Autumn.API.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Autumn.API.Models;

    public class WishService : IWishService
    {
        Task IWishService.AddAsync(Wish entity)
        {
            throw new NotImplementedException();
        }

        void IWishService.Delete(Wish entity)
        {
            throw new NotImplementedException();
        }

        void IWishService.Edit(Wish entity)
        {
            throw new NotImplementedException();
        }

        Wish IWishService.Find(Expression<Func<Wish, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        IQueryable<Wish> IWishService.FindAll(Expression<Func<Wish, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        IQueryable<Wish> IWishService.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<Wish> IWishService.GetAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
