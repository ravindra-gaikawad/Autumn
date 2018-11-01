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
    public class BookPagesController : ControllerBase
    {
        private readonly IBookPageService bookPageService;

        public BookPagesController(IBookPageService bookPageService)
        {
            this.bookPageService = bookPageService;
        }

        // GET: api/BookPages
        [HttpGet]
        public IEnumerable<BookPage> GetBookPage()
        {
            return this.bookPageService.GetAll();
        }

        // GET: api/BookPages/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookPage([FromRoute] long id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var bookPage = await this.bookPageService.GetAsync(id);

            if (bookPage == null)
            {
                return this.NotFound();
            }

            return this.Ok(bookPage);
        }

        // PUT: api/BookPages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookPage([FromRoute] long id, [FromBody] BookPage bookPage)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != bookPage.Id)
            {
                return this.BadRequest();
            }

            if (!await this.BookPageExists(id))
            {
                return this.NotFound();
            }

            this.bookPageService.Edit(bookPage);

            return this.NoContent();
        }

        // POST: api/BookPages
        [HttpPost]
        public async Task<IActionResult> PostBookPage([FromBody] BookPage bookPage)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            await this.bookPageService.AddAsync(bookPage);

            return this.CreatedAtAction("GetBookPage", new { id = bookPage.Id }, bookPage);
        }

        // DELETE: api/BookPages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookPage([FromRoute] long id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var bookPage = await this.bookPageService.GetAsync(id);
            if (bookPage == null)
            {
                return this.NotFound();
            }

            this.bookPageService.Delete(bookPage);

            return this.Ok(bookPage);
        }

        private async Task<bool> BookPageExists(long id)
        {
            var bookPage = await this.bookPageService.GetAsync(id);

            if (bookPage == null)
            {
                return false;
            }

            return true;
        }
    }
}