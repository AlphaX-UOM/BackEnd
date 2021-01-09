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
    public class TourGuideServiceReservationsController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public TourGuideServiceReservationsController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: api/TourGuideServiceReservations
        

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TourGuideServiceReservation>>> GetTourGuideServiceReservations(Guid? userId)
        {
            var events = _context.TourGuideServiceReservations.AsQueryable();
            if (userId != null)
            {
                events = _context.TourGuideServiceReservations.Where(i => i.UserID == userId).Include(pub => pub.TourGuideService).Include(x => x.Cancellation);
            }
            else
            {
                events = _context.TourGuideServiceReservations.Include(pub => pub.TourGuideService).Include(x => x.Cancellation);
            }
            return await events.ToListAsync();
        }

        [HttpGet("Customers")]
        public async Task<ActionResult<IEnumerable<TourGuideServiceReservation>>> GetTourGuideServices(Guid? serveId)
        {
            var events = _context.TourGuideServiceReservations.AsQueryable();

            if (serveId != null)
            {
                events = _context.TourGuideServiceReservations.Where(i => i.TourGuideService.UserID == serveId).Include(pub => pub.User);
            }

            return await events.ToListAsync();
        }

        // GET: api/TourGuideServiceReservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TourGuideServiceReservation>> GetTourGuideServiceReservation(Guid id)
        {
            var tourGuideServiceReservation = await _context.TourGuideServiceReservations.FindAsync(id);

            if (tourGuideServiceReservation == null)
            {
                return NotFound();
            }

            return tourGuideServiceReservation;
        }

        // PUT: api/TourGuideServiceReservations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTourGuideServiceReservation(Guid id, TourGuideServiceReservation tourGuideServiceReservation)
        {
            if (id != tourGuideServiceReservation.ID)
            {
                return BadRequest();
            }

            _context.Entry(tourGuideServiceReservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourGuideServiceReservationExists(id))
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

        // POST: api/TourGuideServiceReservations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TourGuideServiceReservation>> PostTourGuideServiceReservation(TourGuideServiceReservation tourGuideServiceReservation)
        {
            _context.TourGuideServiceReservations.Add(tourGuideServiceReservation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTourGuideServiceReservation", new { id = tourGuideServiceReservation.ID }, tourGuideServiceReservation);
        }

        // DELETE: api/TourGuideServiceReservations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TourGuideServiceReservation>> DeleteTourGuideServiceReservation(Guid id)
        {
            var tourGuideServiceReservation = await _context.TourGuideServiceReservations.FindAsync(id);
            if (tourGuideServiceReservation == null)
            {
                return NotFound();
            }

            _context.TourGuideServiceReservations.Remove(tourGuideServiceReservation);
            await _context.SaveChangesAsync();

            return tourGuideServiceReservation;
        }

        private bool TourGuideServiceReservationExists(Guid id)
        {
            return _context.TourGuideServiceReservations.Any(e => e.ID == id);
        }
    }
}
