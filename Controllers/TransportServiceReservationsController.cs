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
    public class TransportServiceReservationsController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public TransportServiceReservationsController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: api/TransportServiceReservations
        

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransportServiceReservation>>> GetTransportServiceReservations(Guid? userId)
        {
            var events = _context.TransportServiceReservations.AsQueryable();
            if (userId != null)
            {
                events = _context.TransportServiceReservations.Where(i => i.UserID == userId).Include(pub => pub.TransportService).Include(x => x.Cancellation);
            }
            else
            {
                events = _context.TransportServiceReservations.Include(pub => pub.TransportService).Include(x => x.Cancellation);
            }
            return await events.ToListAsync();
        }

        [HttpGet("Customers")]
        public async Task<ActionResult<IEnumerable<TransportServiceReservation>>> GetTransportServices(Guid? serveId)
        {
            var events = _context.TransportServiceReservations.AsQueryable();

            if (serveId != null)
            {
                events = _context.TransportServiceReservations.Where(i => i.TransportService.UserID == serveId).Include(pub => pub.User);
            }

            return await events.ToListAsync();
        }

        // GET: api/TransportServiceReservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransportServiceReservation>> GetTransportServiceReservation(Guid id)
        {
            var transportServiceReservation = await _context.TransportServiceReservations.FindAsync(id);

            if (transportServiceReservation == null)
            {
                return NotFound();
            }

            return transportServiceReservation;
        }

        // PUT: api/TransportServiceReservations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransportServiceReservation(Guid id, TransportServiceReservation transportServiceReservation)
        {
            if (id != transportServiceReservation.ID)
            {
                return BadRequest();
            }

            _context.Entry(transportServiceReservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransportServiceReservationExists(id))
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

        // POST: api/TransportServiceReservations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TransportServiceReservation>> PostTransportServiceReservation(TransportServiceReservation transportServiceReservation)
        {
            _context.TransportServiceReservations.Add(transportServiceReservation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransportServiceReservation", new { id = transportServiceReservation.ID }, transportServiceReservation);
        }

        // DELETE: api/TransportServiceReservations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TransportServiceReservation>> DeleteTransportServiceReservation(Guid id)
        {
            var transportServiceReservation = await _context.TransportServiceReservations.FindAsync(id);
            if (transportServiceReservation == null)
            {
                return NotFound();
            }

            _context.TransportServiceReservations.Remove(transportServiceReservation);
            await _context.SaveChangesAsync();

            return transportServiceReservation;
        }

        private bool TransportServiceReservationExists(Guid id)
        {
            return _context.TransportServiceReservations.Any(e => e.ID == id);
        }
    }
}
