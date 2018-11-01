using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Autumn.API.Models;

namespace Autumn.API.Services
{
    public class EpisodeService : IEpisodeService
    {
        Task IEpisodeService.AddAsync(Episode entity)
        {
            throw new NotImplementedException();
        }

        void IEpisodeService.Delete(Episode entity)
        {
            throw new NotImplementedException();
        }

        void IEpisodeService.Edit(Episode entity)
        {
            throw new NotImplementedException();
        }

        Episode IEpisodeService.Find(Expression<Func<Episode, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        IQueryable<Episode> IEpisodeService.FindAll(Expression<Func<Episode, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        IQueryable<Episode> IEpisodeService.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<Episode> IEpisodeService.GetAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
