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
    public class BookPagesController : ControllerBase
    {
        private readonly AutumnDBContext context;

        public BookPagesController(AutumnDBContext context)
        {
            this.context = context;
        }

        // GET: api/BookPages
        [HttpGet]
        public IEnumerable<BookPage> GetBookPage()
        {
            return this.context.BookPage;
        }

        // GET: api/BookPages/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookPage([FromRoute] long id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var bookPage = await this.context.BookPage.FindAsync(id);

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

            this.context.Entry(bookPage).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.BookPageExists(id))
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

        // POST: api/BookPages
        [HttpPost]
        public async Task<IActionResult> PostBookPage([FromBody] BookPage bookPage)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.context.BookPage.Add(bookPage);
            await this.context.SaveChangesAsync();

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

            var bookPage = await this.context.BookPage.FindAsync(id);
            if (bookPage == null)
            {
                return this.NotFound();
            }

            this.context.BookPage.Remove(bookPage);
            await this.context.SaveChangesAsync();

            return this.Ok(bookPage);
        }

        private bool BookPageExists(long id)
        {
            return this.context.BookPage.Any(e => e.Id == id);
        }
    }
}