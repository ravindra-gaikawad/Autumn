namespace Autumn.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Autumn.API.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Route("api/[controller]")]
    [ApiController]
    public class DiariesController : ControllerBase
    {
        private readonly AutumnDBContext context;

        public DiariesController(AutumnDBContext context)
        {
            this.context = context;
        }

        // GET: api/Diaries
        [HttpGet]
        public IEnumerable<Diary> GetDiary()
        {
            return this.context.Diary;
        }

        // GET: api/Diaries/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiary([FromRoute] long id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var diary = await this.context.Diary.FindAsync(id);

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

            this.context.Entry(diary).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.DiaryExists(id))
                {
                    return this.NotFound();
                }
                else
                {
                    throw;
                }
            }

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

            this.context.Diary.Add(diary);
            await this.context.SaveChangesAsync();

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

            var diary = await this.context.Diary.FindAsync(id);
            if (diary == null)
            {
                return this.NotFound();
            }

            this.context.Diary.Remove(diary);
            await this.context.SaveChangesAsync();

            return this.Ok(diary);
        }

        private bool DiaryExists(long id)
        {
            return this.context.Diary.Any(e => e.Id == id);
        }
    }
}