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
    public class TransportServiceCommentsController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public TransportServiceCommentsController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: api/TransportServiceComments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransportServiceComment>>> GetTransportServiceComments()
        {
            return await _context.TransportServiceComments.ToListAsync();
        }

        // GET: api/TransportServiceComments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransportServiceComment>> GetTransportServiceComment(Guid id)
        {
            var transportServiceComment = await _context.TransportServiceComments.FindAsync(id);

            if (transportServiceComment == null)
            {
                return NotFound();
            }

            return transportServiceComment;
        }

        // PUT: api/TransportServiceComments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransportServiceComment(Guid id, TransportServiceComment transportServiceComment)
        {
            if (id != transportServiceComment.ID)
            {
                return BadRequest();
            }

            _context.Entry(transportServiceComment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransportServiceCommentExists(id))
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

        // POST: api/TransportServiceComments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TransportServiceComment>> PostTransportServiceComment(TransportServiceComment transportServiceComment)
        {
            _context.TransportServiceComments.Add(transportServiceComment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransportServiceComment", new { id = transportServiceComment.ID }, transportServiceComment);
        }

        // DELETE: api/TransportServiceComments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TransportServiceComment>> DeleteTransportServiceComment(Guid id)
        {
            var transportServiceComment = await _context.TransportServiceComments.FindAsync(id);
            if (transportServiceComment == null)
            {
                return NotFound();
            }

            _context.TransportServiceComments.Remove(transportServiceComment);
            await _context.SaveChangesAsync();

            return transportServiceComment;
        }

        private bool TransportServiceCommentExists(Guid id)
        {
            return _context.TransportServiceComments.Any(e => e.ID == id);
        }
    }
}
