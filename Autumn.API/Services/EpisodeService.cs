namespace Autumn.API.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Autumn.API.Models;
    using Autumn.API.Repository;

    public class EpisodeService : IEpisodeService
    {
        private readonly IRepository repository;

        public EpisodeService(IRepository repository)
        {
            this.repository = repository;
        }

        async Task IEpisodeService.AddAsync(Episode entity)
        {
            await this.repository.AddAsync(entity);
        }

        void IEpisodeService.Delete(Episode entity)
        {
            this.repository.Delete(entity);
        }

        void IEpisodeService.Edit(Episode entity)
        {
            this.repository.Edit(entity);
        }

        Episode IEpisodeService.Find(Expression<Func<Episode, bool>> predicate)
        {
            return this.repository.Find(predicate);
        }

        IQueryable<Episode> IEpisodeService.FindAll(Expression<Func<Episode, bool>> predicate)
        {
            return this.repository.FindAll(predicate);
        }

        IQueryable<Episode> IEpisodeService.GetAll()
        {
            return this.repository.GetAll<Episode>();
        }

        async Task<Episode> IEpisodeService.GetAsync(long id)
        {
            return await this.repository.GetAsync<Episode>(id);
        }
    }
}
