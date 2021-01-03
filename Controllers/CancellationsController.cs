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
    public class CancellationsController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public CancellationsController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: api/Cancellations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cancellation>>> GetCancellations()
        {
            return await _context.Cancellations.ToListAsync();
        }

    

        // GET: api/Cancellations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cancellation>> GetCancellation(Guid id)
        {
            var cancellation = await _context.Cancellations.FindAsync(id);

            if (cancellation == null)
            {
                return NotFound();
            }

            return cancellation;
        }

        // PUT: api/Cancellations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCancellation(Guid id, Cancellation cancellation)
        {
            if (id != cancellation.ID)
            {
                return BadRequest();
            }

            _context.Entry(cancellation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CancellationExists(id))
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

        // POST: api/Cancellations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cancellation>> PostCancellation(Cancellation cancellation)
        {
            _context.Cancellations.Add(cancellation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCancellation", new { id = cancellation.ID }, cancellation);
        }

        // DELETE: api/Cancellations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cancellation>> DeleteCancellation(Guid id)
        {
            var cancellation = await _context.Cancellations.FindAsync(id);
            if (cancellation == null)
            {
                return NotFound();
            }

            _context.Cancellations.Remove(cancellation);
            await _context.SaveChangesAsync();

            return cancellation;
        }

        private bool CancellationExists(Guid id)
        {
            return _context.Cancellations.Any(e => e.ID == id);
        }
    }
}
