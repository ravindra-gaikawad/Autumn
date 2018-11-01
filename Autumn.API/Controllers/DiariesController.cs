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
    public class DiariesController : ControllerBase
    {
        private readonly IDiaryService diaryService;

        public DiariesController(IDiaryService diaryService)
        {
            this.diaryService = diaryService;
        }

        // GET: api/Diaries
        [HttpGet]
        public IEnumerable<Diary> GetDiary()
        {
            return this.diaryService.GetAll();
        }

        // GET: api/Diaries/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiary([FromRoute] long id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var diary = await this.diaryService.GetAsync(id);

            if (diary == null)
            {
                return this.NotFound();
            }

            return this.Ok(diary);
        }

        // PUT: api/Diaries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiary([FromRoute] long id, [FromBody] Diary diary)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != diary.Id)
            {
                return this.BadRequest();
            }

            if (!await this.DiaryExists(id))
            {
                return this.NotFound();
            }

            this.diaryService.Edit(diary);

            return this.NoContent();
        }

        // POST: api/Diaries
        [HttpPost]
        public async Task<IActionResult> PostDiary([FromBody] Diary diary)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            await this.diaryService.AddAsync(diary);

            return this.CreatedAtAction("GetDiary", new { id = diary.Id }, diary);
        }

        // DELETE: api/Diaries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiary([FromRoute] long id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var diary = await this.diaryService.GetAsync(id);
            if (diary == null)
            {
                return this.NotFound();
            }

            this.diaryService.Delete(diary);

            return this.Ok(diary);
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
    }
}