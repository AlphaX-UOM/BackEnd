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
    public class TourGuideServiceRatingsController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public TourGuideServiceRatingsController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: api/TourGuideServiceRatings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TourGuideServiceRating>>> GetTourGuideServiceRatings()
        {
            return await _context.TourGuideServiceRatings.ToListAsync();
        }

        // GET: api/TourGuideServiceRatings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TourGuideServiceRating>> GetTourGuideServiceRating(Guid id)
        {
            var tourGuideServiceRating = await _context.TourGuideServiceRatings.FindAsync(id);

            if (tourGuideServiceRating == null)
            {
                return NotFound();
            }

            return tourGuideServiceRating;
        }

        // PUT: api/TourGuideServiceRatings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTourGuideServiceRating(Guid id, TourGuideServiceRating tourGuideServiceRating)
        {
            if (id != tourGuideServiceRating.ID)
            {
                return BadRequest();
            }

            _context.Entry(tourGuideServiceRating).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourGuideServiceRatingExists(id))
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

        // POST: api/TourGuideServiceRatings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TourGuideServiceRating>> PostTourGuideServiceRating(TourGuideServiceRating tourGuideServiceRating)
        {
            _context.TourGuideServiceRatings.Add(tourGuideServiceRating);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTourGuideServiceRating", new { id = tourGuideServiceRating.ID }, tourGuideServiceRating);
        }

        // DELETE: api/TourGuideServiceRatings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TourGuideServiceRating>> DeleteTourGuideServiceRating(Guid id)
        {
            var tourGuideServiceRating = await _context.TourGuideServiceRatings.FindAsync(id);
            if (tourGuideServiceRating == null)
            {
                return NotFound();
            }

            _context.TourGuideServiceRatings.Remove(tourGuideServiceRating);
            await _context.SaveChangesAsync();

            return tourGuideServiceRating;
        }

        private bool TourGuideServiceRatingExists(Guid id)
        {
            return _context.TourGuideServiceRatings.Any(e => e.ID == id);
        }
    }
}
