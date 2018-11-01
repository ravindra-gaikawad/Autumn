using Autumn.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Autumn.API.Services
{
    public interface IDiaryPageService
    {
        Task<DiaryPage> GetAsync(long id);

        DiaryPage Find(Expression<Func<DiaryPage, bool>> predicate);

        IQueryable<DiaryPage> FindAll(Expression<Func<DiaryPage, bool>> predicate);

        IQueryable<DiaryPage> GetAll();

        Task AddAsync(DiaryPage entity);

        void Delete(DiaryPage entity);

        void Edit(DiaryPage entity);
    }
}
