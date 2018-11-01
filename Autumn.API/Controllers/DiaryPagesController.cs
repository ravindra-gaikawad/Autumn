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
    public class DiaryPagesController : ControllerBase
    {
        private readonly AutumnDBContext _context;

        public DiaryPagesController(AutumnDBContext context)
        {
            _context = context;
        }

        // GET: api/DiaryPages
        [HttpGet]
        public IEnumerable<DiaryPage> GetDiaryPage()
        {
            return _context.DiaryPage;
        }

        // GET: api/DiaryPages/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiaryPage([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var diaryPage = await _context.DiaryPage.FindAsync(id);

            if (diaryPage == null)
            {
                return NotFound();
            }

            return Ok(diaryPage);
        }

        // PUT: api/DiaryPages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiaryPage([FromRoute] long id, [FromBody] DiaryPage diaryPage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != diaryPage.Id)
            {
                return BadRequest();
            }

            _context.Entry(diaryPage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiaryPageExists(id))
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

        // POST: api/DiaryPages
        [HttpPost]
        public async Task<IActionResult> PostDiaryPage([FromBody] DiaryPage diaryPage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DiaryPage.Add(diaryPage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiaryPage", new { id = diaryPage.Id }, diaryPage);
        }

        // DELETE: api/DiaryPages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiaryPage([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var diaryPage = await _context.DiaryPage.FindAsync(id);
            if (diaryPage == null)
            {
                return NotFound();
            }

            _context.DiaryPage.Remove(diaryPage);
            await _context.SaveChangesAsync();

            return Ok(diaryPage);
        }

        private bool DiaryPageExists(long id)
        {
            return _context.DiaryPage.Any(e => e.Id == id);
        }
    }
}