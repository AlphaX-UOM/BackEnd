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
    public class EventPlannerServiceRatingsController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public EventPlannerServiceRatingsController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: api/EventPlannerServiceRatings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventPlannerServiceRating>>> GetEventPlannerServiceRatings()
        {
            return await _context.EventPlannerServiceRatings.ToListAsync();
        }

        // GET: api/EventPlannerServiceRatings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventPlannerServiceRating>> GetEventPlannerServiceRating(Guid id)
        {
            var eventPlannerServiceRating = await _context.EventPlannerServiceRatings.FindAsync(id);

            if (eventPlannerServiceRating == null)
            {
                return NotFound();
            }

            return eventPlannerServiceRating;
        }



        // PUT: api/EventPlannerServiceRatings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventPlannerServiceRating(Guid id, EventPlannerServiceRating eventPlannerServiceRating)
        {
            if (id != eventPlannerServiceRating.ID)
            {
                return BadRequest();
            }

            _context.Entry(eventPlannerServiceRating).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventPlannerServiceRatingExists(id))
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

        // POST: api/EventPlannerServiceRatings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EventPlannerServiceRating>> PostEventPlannerServiceRating(EventPlannerServiceRating eventPlannerServiceRating)
        {
            _context.EventPlannerServiceRatings.Add(eventPlannerServiceRating);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventPlannerServiceRating", new { id = eventPlannerServiceRating.ID }, eventPlannerServiceRating);
        }

        // DELETE: api/EventPlannerServiceRatings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EventPlannerServiceRating>> DeleteEventPlannerServiceRating(Guid id)
        {
            var eventPlannerServiceRating = await _context.EventPlannerServiceRatings.FindAsync(id);
            if (eventPlannerServiceRating == null)
            {
                return NotFound();
            }

            _context.EventPlannerServiceRatings.Remove(eventPlannerServiceRating);
            await _context.SaveChangesAsync();

            return eventPlannerServiceRating;
        }

        private bool EventPlannerServiceRatingExists(Guid id)
        {
            return _context.EventPlannerServiceRatings.Any(e => e.ID == id);
        }
    }
}
