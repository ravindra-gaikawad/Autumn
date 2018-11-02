namespace Autumn.API.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Autumn.API.Models;

    public interface IEpisodeService
    {
        Task<Episode> GetAsync(long id);

        Episode Find(Expression<Func<Episode, bool>> predicate);

        IQueryable<Episode> FindAll(Expression<Func<Episode, bool>> predicate);

        IQueryable<Episode> GetAll();

        Task AddAsync(Episode entity);

        void Delete(Episode entity);

        void Edit(Episode entity);
    }
}
