using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Autumn.API.Models;

namespace Autumn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookPagesController : ControllerBase
    {
        private readonly AutumnDBContext _context;

        public BookPagesController(AutumnDBContext context)
        {
            _context = context;
        }

        // GET: api/BookPages
        [HttpGet]
        public IEnumerable<BookPage> GetBookPage()
        {
            return _context.BookPage;
        }

        // GET: api/BookPages/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookPage([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bookPage = await _context.BookPage.FindAsync(id);

            if (bookPage == null)
            {
                return NotFound();
            }

            return Ok(bookPage);
        }

        // PUT: api/BookPages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookPage([FromRoute] long id, [FromBody] BookPage bookPage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bookPage.Id)
            {
                return BadRequest();
            }

            _context.Entry(bookPage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookPageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BookPages
        [HttpPost]
        public async Task<IActionResult> PostBookPage([FromBody] BookPage bookPage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.BookPage.Add(bookPage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookPage", new { id = bookPage.Id }, bookPage);
        }

        // DELETE: api/BookPages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookPage([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bookPage = await _context.BookPage.FindAsync(id);
            if (bookPage == null)
            {
                return NotFound();
            }

            _context.BookPage.Remove(bookPage);
            await _context.SaveChangesAsync();

            return Ok(bookPage);
        }

        private bool BookPageExists(long id)
        {
            return _context.BookPage.Any(e => e.Id == id);
        }
    }
}