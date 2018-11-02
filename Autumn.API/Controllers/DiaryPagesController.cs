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

    [Route("api/diaries")]
    [ApiController]
    public class DiaryPagesController : ControllerBase
    {
        private readonly IDiaryPageService diaryPageService;
        private readonly IDiaryService diaryService;

        public DiaryPagesController(IDiaryPageService diaryPageService, IDiaryService diaryService)
        {
            this.diaryPageService = diaryPageService;
            this.diaryService = diaryService;
        }

        // GET: api/5/Pages/5
        [HttpGet("{diaryId}/pages")]
        public async Task<IEnumerable<DiaryPage>> GetDiaryPage([FromRoute] long diaryId)
        {
            return await this.diaryPageService.GetAllAsync(diaryId);
        }

        // GET: api/DiaryPages/5
        [HttpGet("{diaryId}/pages/{id}")]
        public async Task<IActionResult> GetDiaryPage([FromRoute] long diaryId, [FromRoute] long id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var diaryPage = await this.diaryPageService.GetAsync(diaryId, id);

            if (diaryPage == null)
            {
                return this.NotFound();
            }

            return this.Ok(diaryPage);
        }

        // PUT: api/DiaryPages/5
        [HttpPut("{diaryId}/pages/{id}")]
        public async Task<IActionResult> PutDiaryPage([FromRoute] long diaryId, [FromRoute] long id, [FromBody] DiaryPage diaryPage)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != diaryPage.Id)
            {
                return this.BadRequest();
            }

            if (diaryId != diaryPage.DiaryId)
            {
                return this.BadRequest();
            }

            if (!await this.DiaryPageExists(diaryId, id))
            {
                return this.NotFound();
            }

            this.diaryPageService.Edit(diaryPage);

            return this.NoContent();
        }

        // POST: api/DiaryPages
        [HttpPost("{diaryId}/pages")]
        public async Task<IActionResult> PostDiaryPage([FromRoute] long diaryId, [FromBody] DiaryPage diaryPage)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (!await this.DiaryExists(diaryId))
            {
                return this.NotFound();
            }

            await this.diaryPageService.AddAsync(diaryPage);

            return this.CreatedAtAction("GetDiaryPage", new { id = diaryPage.Id }, diaryPage);
        }

        // DELETE: api/DiaryPages/5
        [HttpDelete("{diaryId}/pages/{id}")]
        public async Task<IActionResult> DeleteDiaryPage([FromRoute] long diaryId, [FromRoute] long id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (!await this.DiaryExists(diaryId))
            {
                return this.NotFound();
            }

            var diaryPage = await this.diaryPageService.GetAsync(diaryId, id);
            if (diaryPage == null)
            {
                return this.NotFound();
            }

            this.diaryPageService.Delete(diaryPage);

            return this.Ok(diaryPage);
        }

        private async Task<bool> DiaryExists(long id)
        {
            var diary = await this.diaryService.GetAsync(id);

            if (diary == null)
            {
                return false;
            }

            return true;
        }

        private async Task<bool> DiaryPageExists(long diaryId, long id)
        {
            var diaryPage = await this.diaryPageService.GetAsync(diaryId, id);

            if (diaryPage == null)
            {
                return false;
            }

            return true;
        }
    }
}