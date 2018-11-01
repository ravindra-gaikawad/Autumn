namespace Autumn.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Autumn.API.Models;
    using Autumn.API.Services;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Route("api/[controller]")]
    [ApiController]
    public class EpisodesController : ControllerBase
    {
        private readonly IEpisodeService episodeService;

        public EpisodesController(IEpisodeService episodeService)
        {
            this.episodeService = episodeService;
        }

        // GET: api/Episodes
        [HttpGet]
        public IEnumerable<Episode> GetEpisode()
        {
            return this.episodeService.GetAll();
        }

        // GET: api/Episodes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEpisode([FromRoute] long id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var episode = await this.episodeService.GetAsync(id);

            if (episode == null)
            {
                return this.NotFound();
            }

            return this.Ok(episode);
        }

        // PUT: api/Episodes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEpisode([FromRoute] long id, [FromBody] Episode episode)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != episode.Id)
            {
                return this.BadRequest();
            }

            if (!await this.EpisodeExists(id))
            {
                return this.NotFound();
            }

            this.episodeService.Edit(episode);

            return this.NoContent();
        }

        // POST: api/Episodes
        [HttpPost]
        public async Task<IActionResult> PostEpisode([FromBody] Episode episode)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            await this.episodeService.AddAsync(episode);

            return this.CreatedAtAction("GetEpisode", new { id = episode.Id }, episode);
        }

        // DELETE: api/Episodes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEpisode([FromRoute] long id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var episode = await this.episodeService.GetAsync(id);
            if (episode == null)
            {
                return this.NotFound();
            }

            this.episodeService.Delete(episode);

            return this.Ok(episode);
        }

        private async Task<bool> EpisodeExists(long id)
        {
            var episode = await this.episodeService.GetAsync(id);

            if (episode == null)
            {
                return false;
            }

            return true;
        }
    }
}