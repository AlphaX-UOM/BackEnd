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
    public class HotelsServiceReservationsController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public HotelsServiceReservationsController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: api/HotelsServiceReservations
        

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelsServiceReservation>>> GetHotelsServiceReservations(Guid? userId)
        {
            var events = _context.HotelsServiceReservations.AsQueryable();
            if (userId != null)
            {
                events = _context.HotelsServiceReservations.Where(i => i.UserID == userId).Include(pub => pub.HotelsService).Include(x => x.Cancellation);
            }
            else
            {
                events = _context.HotelsServiceReservations.Include(pub => pub.HotelsService).Include(x => x.Cancellation);
            }
            return await events.ToListAsync();
        }

        [HttpGet("Customers")]
        public async Task<ActionResult<IEnumerable<HotelsServiceReservation>>> GetHotelsServices(Guid? serveId)
        {
            var events = _context.HotelsServiceReservations.AsQueryable();

            if (serveId != null)
            {
                events = _context.HotelsServiceReservations.Where(i => i.HotelsService.UserID == serveId).Include(pub => pub.User);
            }

            return await events.ToListAsync();
        }

        // GET: api/HotelsServiceReservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelsServiceReservation>> GetHotelsServiceReservation(Guid id)
        {
            var hotelsServiceReservation = await _context.HotelsServiceReservations.FindAsync(id);

            if (hotelsServiceReservation == null)
            {
                return NotFound();
            }

            return hotelsServiceReservation;
        }

        // PUT: api/HotelsServiceReservations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelsServiceReservation(Guid id, HotelsServiceReservation hotelsServiceReservation)
        {
            if (id != hotelsServiceReservation.ID)
            {
                return BadRequest();
            }

            _context.Entry(hotelsServiceReservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelsServiceReservationExists(id))
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

        // POST: api/HotelsServiceReservations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HotelsServiceReservation>> PostHotelsServiceReservation(HotelsServiceReservation hotelsServiceReservation)
        {
            _context.HotelsServiceReservations.Add(hotelsServiceReservation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotelsServiceReservation", new { id = hotelsServiceReservation.ID }, hotelsServiceReservation);
        }

        // DELETE: api/HotelsServiceReservations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HotelsServiceReservation>> DeleteHotelsServiceReservation(Guid id)
        {
            var hotelsServiceReservation = await _context.HotelsServiceReservations.FindAsync(id);
            if (hotelsServiceReservation == null)
            {
                return NotFound();
            }

            _context.HotelsServiceReservations.Remove(hotelsServiceReservation);
            await _context.SaveChangesAsync();

            return hotelsServiceReservation;
        }

        private bool HotelsServiceReservationExists(Guid id)
        {
            return _context.HotelsServiceReservations.Any(e => e.ID == id);
        }
    }
}
