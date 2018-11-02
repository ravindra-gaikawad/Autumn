namespace Autumn.API.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Autumn.API.Models;
    using Autumn.API.Repository;

    public class DiaryService : IDiaryService
    {
        private readonly IRepository repository;

        public DiaryService(IRepository repository)
        {
            this.repository = repository;
        }

        async Task IDiaryService.AddAsync(Diary entity)
        {
            await this.repository.AddAsync(entity);
        }

        void IDiaryService.Delete(Diary entity)
        {
            this.repository.Delete(entity);
        }

        void IDiaryService.Edit(Diary entity)
        {
            this.repository.Edit(entity);
        }

        async Task<Diary> IDiaryService.FindAsync(Expression<Func<Diary, bool>> predicate)
        {
            return await this.repository.FindAsync(predicate);
        }

        IQueryable<Diary> IDiaryService.FindAll(Expression<Func<Diary, bool>> predicate)
        {
            return this.repository.FindAll(predicate);
        }

        IQueryable<Diary> IDiaryService.GetAll()
        {
            return this.repository.GetAll<Diary>();
        }

        async Task<Diary> IDiaryService.GetAsync(long id)
        {
            return await this.repository.GetAsync<Diary>(id);
        }
    }
}
