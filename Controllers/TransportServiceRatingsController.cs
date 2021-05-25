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
    public class TransportServiceRatingsController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public TransportServiceRatingsController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: api/TransportServiceRatings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransportServiceRating>>> GetTransportServiceRatings()
        {
            return await _context.TransportServiceRatings.ToListAsync();
        }

        // GET: api/TransportServiceRatings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransportServiceRating>> GetTransportServiceRating(Guid id)
        {
            var transportServiceRating = await _context.TransportServiceRatings.FindAsync(id);

            if (transportServiceRating == null)
            {
                return NotFound();
            }

            return transportServiceRating;
        }

        // PUT: api/TransportServiceRatings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransportServiceRating(Guid id, TransportServiceRating transportServiceRating)
        {
            if (id != transportServiceRating.ID)
            {
                return BadRequest();
            }

            _context.Entry(transportServiceRating).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransportServiceRatingExists(id))
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

        // POST: api/TransportServiceRatings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TransportServiceRating>> PostTransportServiceRating(TransportServiceRating transportServiceRating)
        {
            _context.TransportServiceRatings.Add(transportServiceRating);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransportServiceRating", new { id = transportServiceRating.ID }, transportServiceRating);
        }

        // DELETE: api/TransportServiceRatings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TransportServiceRating>> DeleteTransportServiceRating(Guid id)
        {
            var transportServiceRating = await _context.TransportServiceRatings.FindAsync(id);
            if (transportServiceRating == null)
            {
                return NotFound();
            }

            _context.TransportServiceRatings.Remove(transportServiceRating);
            await _context.SaveChangesAsync();

            return transportServiceRating;
        }

        private bool TransportServiceRatingExists(Guid id)
        {
            return _context.TransportServiceRatings.Any(e => e.ID == id);
        }
    }
}
