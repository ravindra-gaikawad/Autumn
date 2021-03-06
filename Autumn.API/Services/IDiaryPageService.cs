﻿namespace Autumn.API.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Autumn.API.Models;

    public interface IDiaryPageService
    {
        Task<DiaryPage> GetAsync(long diaryId, long id);

        Task<DiaryPage> FindAsync(Expression<Func<DiaryPage, bool>> predicate);

        IQueryable<DiaryPage> FindAll(Expression<Func<DiaryPage, bool>> predicate);

        Task<IQueryable<DiaryPage>> GetAllAsync(long diaryId);

        Task AddAsync(DiaryPage entity);

        void Delete(DiaryPage entity);

        void Edit(DiaryPage entity);
    }
}
