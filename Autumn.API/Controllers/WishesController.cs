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
    public class WishesController : ControllerBase
    {
        private readonly AutumnDBContext _context;

        public WishesController(AutumnDBContext context)
        {
            _context = context;
        }

        // GET: api/Wishes
        [HttpGet]
        public IEnumerable<Wish> GetWish()
        {
            return _context.Wish;
        }

        // GET: api/Wishes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWish([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var wish = await _context.Wish.FindAsync(id);

            if (wish == null)
            {
                return NotFound();
            }

            return Ok(wish);
        }

        // PUT: api/Wishes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWish([FromRoute] long id, [FromBody] Wish wish)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wish.Id)
            {
                return BadRequest();
            }

            _context.Entry(wish).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WishExists(id))
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

        // POST: api/Wishes
        [HttpPost]
        public async Task<IActionResult> PostWish([FromBody] Wish wish)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Wish.Add(wish);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWish", new { id = wish.Id }, wish);
        }

        // DELETE: api/Wishes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWish([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var wish = await _context.Wish.FindAsync(id);
            if (wish == null)
            {
                return NotFound();
            }

            _context.Wish.Remove(wish);
            await _context.SaveChangesAsync();

            return Ok(wish);
        }

        private bool WishExists(long id)
        {
            return _context.Wish.Any(e => e.Id == id);
        }
    }
}