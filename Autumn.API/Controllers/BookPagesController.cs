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

    [Route("api/books")]
    [ApiController]
    public class BookPagesController : ControllerBase
    {
        private readonly IBookPageService bookPageService;
        private readonly IBookService bookService;

        public BookPagesController(IBookPageService bookPageService, IBookService bookService)
        {
            this.bookPageService = bookPageService;
            this.bookService = bookService;
        }

        // GET: api/BookPages
        [HttpGet("{bookId}/pages")]
        public async Task<IEnumerable<BookPage>> GetBookPage([FromRoute] long bookId)
        {
            return await this.bookPageService.GetAllAsync(bookId);
        }

        // GET: api/BookPages/5
        [HttpGet("{bookId}/pages/{id}")]
        public async Task<IActionResult> GetBookPage([FromRoute] long bookId, [FromRoute] long id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var bookPage = await this.bookPageService.GetAsync(bookId, id);

            if (bookPage == null)
            {
                return this.NotFound();
            }

            return this.Ok(bookPage);
        }

        // PUT: api/BookPages/5
        [HttpPut("{bookId}/pages/{id}")]
        public async Task<IActionResult> PutBookPage([FromRoute] long bookId, [FromRoute] long id, [FromBody] BookPage bookPage)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != bookPage.Id)
            {
                return this.BadRequest();
            }

            if (bookId != bookPage.BookId)
            {
                return this.BadRequest();
            }

            if (!await this.BookPageExists(bookId, id))
            {
                return this.NotFound();
            }

            this.bookPageService.Edit(bookPage);

            return this.NoContent();
        }

        // POST: api/BookPages
        [HttpPost("{bookId}/pages")]
        public async Task<IActionResult> PostBookPage([FromRoute] long bookId, [FromBody] BookPage bookPage)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (!await this.BookExists(bookId))
            {
                return this.NotFound();
            }

            await this.bookPageService.AddAsync(bookPage);

            return this.CreatedAtAction("GetBookPage", new { id = bookPage.Id }, bookPage);
        }

        // DELETE: api/BookPages/5
        [HttpDelete("{bookId}/pages/{id}")]
        public async Task<IActionResult> DeleteBookPage([FromRoute] long bookId, [FromRoute] long id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (!await this.BookExists(bookId))
            {
                return this.NotFound();
            }

            var bookPage = await this.bookPageService.GetAsync(bookId, id);
            if (bookPage == null)
            {
                return this.NotFound();
            }

            this.bookPageService.Delete(bookPage);

            return this.Ok(bookPage);
        }

        private async Task<bool> BookExists(long id)
        {
            var book = await this.bookService.GetAsync(id);

            if (book == null)
            {
                return false;
            }

            return true;
        }

        private async Task<bool> BookPageExists(long bookId, long id)
        {
            var bookPage = await this.bookPageService.GetAsync(bookId, id);

            if (bookPage == null)
            {
                return false;
            }

            return true;
        }
    }
}