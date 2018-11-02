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
    public class WishesController : ControllerBase
    {
        private readonly IWishService wishService;

        public WishesController(IWishService wishService)
        {
            this.wishService = wishService;
        }

        // GET: api/Wishes
        [HttpGet]
        public IEnumerable<Wish> GetWish()
        {
            return this.wishService.GetAll();
        }

        // GET: api/Wishes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWish([FromRoute] long id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var wish = await this.wishService.GetAsync(id);

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

            if (!await this.WishExists(id))
            {
                return this.NotFound();
            }

            this.wishService.Edit(wish);

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

            await this.wishService.AddAsync(wish);

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

            var wish = await this.wishService.GetAsync(id);
            if (wish == null)
            {
                return this.NotFound();
            }

            this.wishService.Delete(wish);

            return this.Ok(wish);
        }

        private async Task<bool> WishExists(long id)
        {
            var wish = await this.wishService.GetAsync(id);

            if (wish == null)
            {
                return false;
            }

            return true;
        }
    }
}