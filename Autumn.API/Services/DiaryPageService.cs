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

        async Task<DiaryPage> IDiaryPageService.FindAsync(Expression<Func<DiaryPage, bool>> predicate)
        {
            return await this.repository.FindAsync(predicate);
        }

        IQueryable<DiaryPage> IDiaryPageService.FindAll(Expression<Func<DiaryPage, bool>> predicate)
        {
            return this.repository.FindAll(predicate);
        }

        async Task<IQueryable<DiaryPage>> IDiaryPageService.GetAllAsync(long diaryId)
        {
            var diary = await this.repository.GetAsync<Diary>(diaryId);

            if (diary == null)
            {
                return null;
            }

            return this.repository.FindAll<DiaryPage>(p => p.DiaryId == diaryId);
        }

        async Task<DiaryPage> IDiaryPageService.GetAsync(long diaryId, long id)
        {
            var diary = await this.repository.GetAsync<Diary>(diaryId);

            if (diary == null)
            {
                return null;
            }

            return await this.repository.FindAsync<DiaryPage>(p => p.DiaryId == diaryId);
        }
    }
}
