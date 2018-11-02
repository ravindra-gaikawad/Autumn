namespace Autumn.API.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Autumn.API.Models;
    using Autumn.API.Repository;

    public class UserService : IUserService
    {
        private readonly IRepository repository;

        public UserService(IRepository repository)
        {
            this.repository = repository;
        }

        async Task IUserService.AddAsync(User entity)
        {
            await this.repository.AddAsync(entity);
        }

        void IUserService.Delete(User entity)
        {
            this.repository.Delete(entity);
        }

        void IUserService.Edit(User entity)
        {
            this.repository.Edit(entity);
        }

        User IUserService.Find(Expression<Func<User, bool>> predicate)
        {
            return this.repository.Find(predicate);
        }

        IQueryable<User> IUserService.FindAll(Expression<Func<User, bool>> predicate)
        {
            return this.repository.FindAll(predicate);
        }

        IQueryable<User> IUserService.GetAll()
        {
            return this.repository.GetAll<User>();
        }

        async Task<User> IUserService.GetAsync(long id)
        {
            return await this.repository.GetAsync<User>(id);
        }
    }
}
