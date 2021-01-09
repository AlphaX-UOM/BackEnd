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
    public class EventPlannerServiceReservationsController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public EventPlannerServiceReservationsController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: api/EventPlannerServiceReservations
        

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventPlannerServiceReservation>>> GetEventPlannerServiceReservations(Guid? userId)
        {
            var events = _context.EventPlannerServiceReservations.AsQueryable();
            if (userId != null)
            {
                events = _context.EventPlannerServiceReservations.Where(i => i.UserID == userId).Include(pub => pub.EventPlannerService).Include(x => x.Cancellation);
            }
            else
            {
                events = _context.EventPlannerServiceReservations.Include(pub => pub.EventPlannerService).Include(x => x.Cancellation);
            }
            return await events.ToListAsync();
        }

        [HttpGet("Customers")]
        public async Task<ActionResult<IEnumerable<EventPlannerServiceReservation>>> GetEventPlannerServices(Guid? serveId)
        {
            var events = _context.EventPlannerServiceReservations.AsQueryable();

            if (serveId != null)
            {
                events = _context.EventPlannerServiceReservations.Where(i => i.EventPlannerService.UserID == serveId).Include(pub => pub.User);
            }

            return await events.ToListAsync();
        }


        // GET: api/EventPlannerServiceReservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventPlannerServiceReservation>> GetEventPlannerServiceReservation(Guid id)
        {
            var eventPlannerServiceReservation = await _context.EventPlannerServiceReservations.FindAsync(id);

            if (eventPlannerServiceReservation == null)
            {
                return NotFound();
            }

            return eventPlannerServiceReservation;
        }

        // PUT: api/EventPlannerServiceReservations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventPlannerServiceReservation(Guid id, EventPlannerServiceReservation eventPlannerServiceReservation)
        {
            if (id != eventPlannerServiceReservation.ID)
            {
                return BadRequest();
            }

            _context.Entry(eventPlannerServiceReservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventPlannerServiceReservationExists(id))
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

        // POST: api/EventPlannerServiceReservations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EventPlannerServiceReservation>> PostEventPlannerServiceReservation(EventPlannerServiceReservation eventPlannerServiceReservation)
        {
            _context.EventPlannerServiceReservations.Add(eventPlannerServiceReservation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventPlannerServiceReservation", new { id = eventPlannerServiceReservation.ID }, eventPlannerServiceReservation);
        }

        // DELETE: api/EventPlannerServiceReservations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EventPlannerServiceReservation>> DeleteEventPlannerServiceReservation(Guid id)
        {
            var eventPlannerServiceReservation = await _context.EventPlannerServiceReservations.FindAsync(id);
            if (eventPlannerServiceReservation == null)
            {
                return NotFound();
            }

            _context.EventPlannerServiceReservations.Remove(eventPlannerServiceReservation);
            await _context.SaveChangesAsync();

            return eventPlannerServiceReservation;
        }

        private bool EventPlannerServiceReservationExists(Guid id)
        {
            return _context.EventPlannerServiceReservations.Any(e => e.ID == id);
        }
    }
}
