namespace Autumn.API.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Autumn.API.Models;

    public class DiaryService : IDiaryService
    {
        Task IDiaryService.AddAsync(Diary entity)
        {
            throw new NotImplementedException();
        }

        void IDiaryService.Delete(Diary entity)
        {
            throw new NotImplementedException();
        }

        void IDiaryService.Edit(Diary entity)
        {
            throw new NotImplementedException();
        }

        Diary IDiaryService.Find(Expression<Func<Diary, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        IQueryable<Diary> IDiaryService.FindAll(Expression<Func<Diary, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        IQueryable<Diary> IDiaryService.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<Diary> IDiaryService.GetAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
