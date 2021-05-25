using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuggestorCodeFirstAPI;
using SuggestorCodeFirstAPI.Models;

namespace SuggestorCodeFirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsServiceRatingsController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public HotelsServiceRatingsController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: api/HotelsServiceRatings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelsServiceRating>>> GetHotelsServiceRatings()
        {
            return await _context.HotelsServiceRatings.ToListAsync();
        }

        // GET: api/HotelsServiceRatings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelsServiceRating>> GetHotelsServiceRating(Guid id)
        {
            var hotelsServiceRating = await _context.HotelsServiceRatings.FindAsync(id);

            if (hotelsServiceRating == null)
            {
                return NotFound();
            }

            return hotelsServiceRating;
        }

        // PUT: api/HotelsServiceRatings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelsServiceRating(Guid id, HotelsServiceRating hotelsServiceRating)
        {
            if (id != hotelsServiceRating.ID)
            {
                return BadRequest();
            }

            _context.Entry(hotelsServiceRating).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelsServiceRatingExists(id))
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

        // POST: api/HotelsServiceRatings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HotelsServiceRating>> PostHotelsServiceRating(HotelsServiceRating hotelsServiceRating)
        {
            _context.HotelsServiceRatings.Add(hotelsServiceRating);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotelsServiceRating", new { id = hotelsServiceRating.ID }, hotelsServiceRating);
        }

        // DELETE: api/HotelsServiceRatings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HotelsServiceRating>> DeleteHotelsServiceRating(Guid id)
        {
            var hotelsServiceRating = await _context.HotelsServiceRatings.FindAsync(id);
            if (hotelsServiceRating == null)
            {
                return NotFound();
            }

            _context.HotelsServiceRatings.Remove(hotelsServiceRating);
            await _context.SaveChangesAsync();

            return hotelsServiceRating;
        }

        private bool HotelsServiceRatingExists(Guid id)
        {
            return _context.HotelsServiceRatings.Any(e => e.ID == id);
        }
    }
}
