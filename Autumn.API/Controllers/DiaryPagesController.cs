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
    public class DiaryPagesController : ControllerBase
    {
        private readonly IDiaryPageService diaryPageService;

        public DiaryPagesController(IDiaryPageService diaryPageService)
        {
            this.diaryPageService = diaryPageService;
        }

        // GET: api/DiaryPages
        [HttpGet]
        public IEnumerable<DiaryPage> GetDiaryPage()
        {
            return this.diaryPageService.GetAll();
        }

        // GET: api/DiaryPages/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiaryPage([FromRoute] long id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var diaryPage = await this.diaryPageService.GetAsync(id);

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

            if (!await this.DiaryPageExists(id))
            {
                return this.NotFound();
            }

            this.diaryPageService.Edit(diaryPage);

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

            await this.diaryPageService.AddAsync(diaryPage);

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

            var diaryPage = await this.diaryPageService.GetAsync(id);
            if (diaryPage == null)
            {
                return this.NotFound();
            }

            this.diaryPageService.Delete(diaryPage);

            return this.Ok(diaryPage);
        }

        private async Task<bool> DiaryPageExists(long id)
        {
            var diaryPage = await this.diaryPageService.GetAsync(id);

            if (diaryPage == null)
            {
                return false;
            }

            return true;
        }
    }
}