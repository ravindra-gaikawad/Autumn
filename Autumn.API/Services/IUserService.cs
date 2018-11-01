using Autumn.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Autumn.API.Services
{
    public interface IUserService
    {
        Task<User> GetAsync(long id);

        User Find(Expression<Func<User, bool>> predicate);

        IQueryable<User> FindAll(Expression<Func<User, bool>> predicate);

        IQueryable<User> GetAll();

        Task AddAsync(User entity);

        void Delete(User entity);

        void Edit(User entity);
    }
}
