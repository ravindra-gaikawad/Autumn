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
    public class DiariesController : ControllerBase
    {
        private readonly AutumnDBContext _context;

        public DiariesController(AutumnDBContext context)
        {
            _context = context;
        }

        // GET: api/Diaries
        [HttpGet]
        public IEnumerable<Diary> GetDiary()
        {
            return _context.Diary;
        }

        // GET: api/Diaries/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiary([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var diary = await _context.Diary.FindAsync(id);

            if (diary == null)
            {
                return NotFound();
            }

            return Ok(diary);
        }

        // PUT: api/Diaries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiary([FromRoute] long id, [FromBody] Diary diary)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != diary.Id)
            {
                return BadRequest();
            }

            _context.Entry(diary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiaryExists(id))
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

        // POST: api/Diaries
        [HttpPost]
        public async Task<IActionResult> PostDiary([FromBody] Diary diary)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Diary.Add(diary);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiary", new { id = diary.Id }, diary);
        }

        // DELETE: api/Diaries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiary([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var diary = await _context.Diary.FindAsync(id);
            if (diary == null)
            {
                return NotFound();
            }

            _context.Diary.Remove(diary);
            await _context.SaveChangesAsync();

            return Ok(diary);
        }

        private bool DiaryExists(long id)
        {
            return _context.Diary.Any(e => e.Id == id);
        }
    }
}