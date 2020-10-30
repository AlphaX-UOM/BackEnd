using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eventPlanner.Models;

namespace eventPlanner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventPlannersController : ControllerBase
    {
        private readonly EventPlannerContext _context;

        public EventPlannersController(EventPlannerContext context)
        {
            _context = context;
        }

        // GET: api/EventPlanners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventPlanner>>> GetEventPlanner()
        {
            return await _context.EventPlanner.ToListAsync();
        }

        // GET: api/EventPlanners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventPlanner>> GetEventPlanner(string id)
        {
            var eventPlanner = await _context.EventPlanner.FindAsync(id);

            if (eventPlanner == null)
            {
                return NotFound();
            }

            return eventPlanner;
        }

        // PUT: api/EventPlanners/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventPlanner(string id, EventPlanner eventPlanner)
        {
            if (id != eventPlanner.EventId)
            {
                return BadRequest();
            }

            _context.Entry(eventPlanner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventPlannerExists(id))
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

        // POST: api/EventPlanners
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EventPlanner>> PostEventPlanner(EventPlanner eventPlanner)
        {
            _context.EventPlanner.Add(eventPlanner);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EventPlannerExists(eventPlanner.EventId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEventPlanner", new { id = eventPlanner.EventId }, eventPlanner);
        }

        // DELETE: api/EventPlanners/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EventPlanner>> DeleteEventPlanner(string id)
        {
            var eventPlanner = await _context.EventPlanner.FindAsync(id);
            if (eventPlanner == null)
            {
                return NotFound();
            }

            _context.EventPlanner.Remove(eventPlanner);
            await _context.SaveChangesAsync();

            return eventPlanner;
        }

        private bool EventPlannerExists(string id)
        {
            return _context.EventPlanner.Any(e => e.EventId == id);
        }
    }
}
