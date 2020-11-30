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
    public class HotelsServiceCommentsController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public HotelsServiceCommentsController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: api/HotelsServiceComments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelsServiceComment>>> GetHotelsServiceComments()
        {
            return await _context.HotelsServiceComments.ToListAsync();
        }

        // GET: api/HotelsServiceComments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelsServiceComment>> GetHotelsServiceComment(Guid id)
        {
            var hotelsServiceComment = await _context.HotelsServiceComments.FindAsync(id);

            if (hotelsServiceComment == null)
            {
                return NotFound();
            }

            return hotelsServiceComment;
        }

        // PUT: api/HotelsServiceComments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelsServiceComment(Guid id, HotelsServiceComment hotelsServiceComment)
        {
            if (id != hotelsServiceComment.ID)
            {
                return BadRequest();
            }

            _context.Entry(hotelsServiceComment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelsServiceCommentExists(id))
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

        // POST: api/HotelsServiceComments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HotelsServiceComment>> PostHotelsServiceComment(HotelsServiceComment hotelsServiceComment)
        {
            _context.HotelsServiceComments.Add(hotelsServiceComment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotelsServiceComment", new { id = hotelsServiceComment.ID }, hotelsServiceComment);
        }

        // DELETE: api/HotelsServiceComments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HotelsServiceComment>> DeleteHotelsServiceComment(Guid id)
        {
            var hotelsServiceComment = await _context.HotelsServiceComments.FindAsync(id);
            if (hotelsServiceComment == null)
            {
                return NotFound();
            }

            _context.HotelsServiceComments.Remove(hotelsServiceComment);
            await _context.SaveChangesAsync();

            return hotelsServiceComment;
        }

        private bool HotelsServiceCommentExists(Guid id)
        {
            return _context.HotelsServiceComments.Any(e => e.ID == id);
        }
    }
}
