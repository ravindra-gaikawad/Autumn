namespace Autumn.API.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Autumn.API.Models;

    public class DiaryPageService : IDiaryPageService
    {
        Task IDiaryPageService.AddAsync(DiaryPage entity)
        {
            throw new NotImplementedException();
        }

        void IDiaryPageService.Delete(DiaryPage entity)
        {
            throw new NotImplementedException();
        }

        void IDiaryPageService.Edit(DiaryPage entity)
        {
            throw new NotImplementedException();
        }

        DiaryPage IDiaryPageService.Find(Expression<Func<DiaryPage, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        IQueryable<DiaryPage> IDiaryPageService.FindAll(Expression<Func<DiaryPage, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        IQueryable<DiaryPage> IDiaryPageService.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<DiaryPage> IDiaryPageService.GetAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
