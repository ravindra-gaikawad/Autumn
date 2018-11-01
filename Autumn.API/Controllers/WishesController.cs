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
    public class WishesController : ControllerBase
    {
        private readonly AutumnDBContext context;

        public WishesController(AutumnDBContext context)
        {
            this.context = context;
        }

        // GET: api/Wishes
        [HttpGet]
        public IEnumerable<Wish> GetWish()
        {
            return this.context.Wish;
        }

        // GET: api/Wishes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWish([FromRoute] long id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var wish = await this.context.Wish.FindAsync(id);

            if (wish == null)
            {
                return this.NotFound();
            }

            return this.Ok(wish);
        }

        // PUT: api/Wishes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWish([FromRoute] long id, [FromBody] Wish wish)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != wish.Id)
            {
                return this.BadRequest();
            }

            this.context.Entry(wish).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.WishExists(id))
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

        // POST: api/Wishes
        [HttpPost]
        public async Task<IActionResult> PostWish([FromBody] Wish wish)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.context.Wish.Add(wish);
            await this.context.SaveChangesAsync();

            return this.CreatedAtAction("GetWish", new { id = wish.Id }, wish);
        }

        // DELETE: api/Wishes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWish([FromRoute] long id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var wish = await this.context.Wish.FindAsync(id);
            if (wish == null)
            {
                return this.NotFound();
            }

            this.context.Wish.Remove(wish);
            await this.context.SaveChangesAsync();

            return this.Ok(wish);
        }

        private bool WishExists(long id)
        {
            return this.context.Wish.Any(e => e.Id == id);
        }
    }
}