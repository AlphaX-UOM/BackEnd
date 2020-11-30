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
    public class TransportTypesController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public TransportTypesController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: api/TransportTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransportType>>> GetTransportTypes()
        {
            return await _context.TransportTypes.ToListAsync();
        }

        // GET: api/TransportTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransportType>> GetTransportType(Guid id)
        {
            var transportType = await _context.TransportTypes.FindAsync(id);

            if (transportType == null)
            {
                return NotFound();
            }

            return transportType;
        }

        // PUT: api/TransportTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransportType(Guid id, TransportType transportType)
        {
            if (id != transportType.ID)
            {
                return BadRequest();
            }

            _context.Entry(transportType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransportTypeExists(id))
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

        // POST: api/TransportTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TransportType>> PostTransportType(TransportType transportType)
        {
            _context.TransportTypes.Add(transportType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransportType", new { id = transportType.ID }, transportType);
        }

        // DELETE: api/TransportTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TransportType>> DeleteTransportType(Guid id)
        {
            var transportType = await _context.TransportTypes.FindAsync(id);
            if (transportType == null)
            {
                return NotFound();
            }

            _context.TransportTypes.Remove(transportType);
            await _context.SaveChangesAsync();

            return transportType;
        }

        private bool TransportTypeExists(Guid id)
        {
            return _context.TransportTypes.Any(e => e.ID == id);
        }
    }
}
