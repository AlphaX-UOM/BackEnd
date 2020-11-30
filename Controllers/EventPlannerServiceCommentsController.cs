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
    public class EventPlannerServiceCommentsController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public EventPlannerServiceCommentsController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: api/EventPlannerServiceComments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventPlannerServiceComment>>> GetEventPlannerServiceComments()
        {
            return await _context.EventPlannerServiceComments.ToListAsync();
        }

        // GET: api/EventPlannerServiceComments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventPlannerServiceComment>> GetEventPlannerServiceComment(Guid id)
        {
            var eventPlannerServiceComment = await _context.EventPlannerServiceComments.FindAsync(id);

            if (eventPlannerServiceComment == null)
            {
                return NotFound();
            }

            return eventPlannerServiceComment;
        }

        // PUT: api/EventPlannerServiceComments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventPlannerServiceComment(Guid id, EventPlannerServiceComment eventPlannerServiceComment)
        {
            if (id != eventPlannerServiceComment.ID)
            {
                return BadRequest();
            }

            _context.Entry(eventPlannerServiceComment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventPlannerServiceCommentExists(id))
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

        // POST: api/EventPlannerServiceComments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EventPlannerServiceComment>> PostEventPlannerServiceComment(EventPlannerServiceComment eventPlannerServiceComment)
        {
            _context.EventPlannerServiceComments.Add(eventPlannerServiceComment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventPlannerServiceComment", new { id = eventPlannerServiceComment.ID }, eventPlannerServiceComment);
        }

        // DELETE: api/EventPlannerServiceComments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EventPlannerServiceComment>> DeleteEventPlannerServiceComment(Guid id)
        {
            var eventPlannerServiceComment = await _context.EventPlannerServiceComments.FindAsync(id);
            if (eventPlannerServiceComment == null)
            {
                return NotFound();
            }

            _context.EventPlannerServiceComments.Remove(eventPlannerServiceComment);
            await _context.SaveChangesAsync();

            return eventPlannerServiceComment;
        }

        private bool EventPlannerServiceCommentExists(Guid id)
        {
            return _context.EventPlannerServiceComments.Any(e => e.ID == id);
        }
    }
}
