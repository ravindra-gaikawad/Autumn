namespace Autumn.API.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Autumn.API.Models;

    public class UserService : IUserService
    {
        Task IUserService.AddAsync(User entity)
        {
            throw new NotImplementedException();
        }

        void IUserService.Delete(User entity)
        {
            throw new NotImplementedException();
        }

        void IUserService.Edit(User entity)
        {
            throw new NotImplementedException();
        }

        User IUserService.Find(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        IQueryable<User> IUserService.FindAll(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        IQueryable<User> IUserService.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<User> IUserService.GetAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
