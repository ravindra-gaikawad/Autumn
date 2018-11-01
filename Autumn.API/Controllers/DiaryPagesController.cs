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
    public class DiaryPagesController : ControllerBase
    {
        private readonly AutumnDBContext context;

        public DiaryPagesController(AutumnDBContext context)
        {
            this.context = context;
        }

        // GET: api/DiaryPages
        [HttpGet]
        public IEnumerable<DiaryPage> GetDiaryPage()
        {
            return this.context.DiaryPage;
        }

        // GET: api/DiaryPages/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiaryPage([FromRoute] long id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var diaryPage = await this.context.DiaryPage.FindAsync(id);

            if (diaryPage == null)
            {
                return this.NotFound();
            }

            return this.Ok(diaryPage);
        }

        // PUT: api/DiaryPages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiaryPage([FromRoute] long id, [FromBody] DiaryPage diaryPage)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != diaryPage.Id)
            {
                return this.BadRequest();
            }

            this.context.Entry(diaryPage).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.DiaryPageExists(id))
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

        // POST: api/DiaryPages
        [HttpPost]
        public async Task<IActionResult> PostDiaryPage([FromBody] DiaryPage diaryPage)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.context.DiaryPage.Add(diaryPage);
            await this.context.SaveChangesAsync();

            return this.CreatedAtAction("GetDiaryPage", new { id = diaryPage.Id }, diaryPage);
        }

        // DELETE: api/DiaryPages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiaryPage([FromRoute] long id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var diaryPage = await this.context.DiaryPage.FindAsync(id);
            if (diaryPage == null)
            {
                return this.NotFound();
            }

            this.context.DiaryPage.Remove(diaryPage);
            await this.context.SaveChangesAsync();

            return this.Ok(diaryPage);
        }

        private bool DiaryPageExists(long id)
        {
            return this.context.DiaryPage.Any(e => e.Id == id);
        }
    }
}