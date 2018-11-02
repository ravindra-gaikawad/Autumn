namespace Autumn.API.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Autumn.API.Models;

    public interface IDiaryService
    {
        Task<Diary> GetAsync(long id);

        Diary Find(Expression<Func<Diary, bool>> predicate);

        IQueryable<Diary> FindAll(Expression<Func<Diary, bool>> predicate);

        IQueryable<Diary> GetAll();

        Task AddAsync(Diary entity);

        void Delete(Diary entity);

        void Edit(Diary entity);
    }
}
