namespace Autumn.API.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Autumn.API.Models;
    using Autumn.API.Repository;

    public class DiaryPageService : IDiaryPageService
    {
        private readonly IRepository repository;

        public DiaryPageService(IRepository repository)
        {
            this.repository = repository;
        }

       async Task IDiaryPageService.AddAsync(DiaryPage entity)
        {
            await this.repository.AddAsync(entity);
        }

        void IDiaryPageService.Delete(DiaryPage entity)
        {
            this.repository.Delete(entity);
        }

        void IDiaryPageService.Edit(DiaryPage entity)
        {
            this.repository.Edit(entity);
        }

        DiaryPage IDiaryPageService.Find(Expression<Func<DiaryPage, bool>> predicate)
        {
            return this.repository.Find(predicate);
        }

        IQueryable<DiaryPage> IDiaryPageService.FindAll(Expression<Func<DiaryPage, bool>> predicate)
        {
            return this.repository.FindAll(predicate);
        }

        IQueryable<DiaryPage> IDiaryPageService.GetAll()
        {
            return this.repository.GetAll<DiaryPage>();
        }

        async Task<DiaryPage> IDiaryPageService.GetAsync(long id)
        {
            return await this.repository.GetAsync<DiaryPage>(id);
        }
    }
}
