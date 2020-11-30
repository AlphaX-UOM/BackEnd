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
    public class TourGuideServiceCommentsController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public TourGuideServiceCommentsController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: api/TourGuideServiceComments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TourGuideServiceComment>>> GetTourGuideServiceComments()
        {
            return await _context.TourGuideServiceComments.ToListAsync();
        }

        // GET: api/TourGuideServiceComments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TourGuideServiceComment>> GetTourGuideServiceComment(Guid id)
        {
            var tourGuideServiceComment = await _context.TourGuideServiceComments.FindAsync(id);

            if (tourGuideServiceComment == null)
            {
                return NotFound();
            }

            return tourGuideServiceComment;
        }

        // PUT: api/TourGuideServiceComments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTourGuideServiceComment(Guid id, TourGuideServiceComment tourGuideServiceComment)
        {
            if (id != tourGuideServiceComment.ID)
            {
                return BadRequest();
            }

            _context.Entry(tourGuideServiceComment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourGuideServiceCommentExists(id))
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

        // POST: api/TourGuideServiceComments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TourGuideServiceComment>> PostTourGuideServiceComment(TourGuideServiceComment tourGuideServiceComment)
        {
            _context.TourGuideServiceComments.Add(tourGuideServiceComment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTourGuideServiceComment", new { id = tourGuideServiceComment.ID }, tourGuideServiceComment);
        }

        // DELETE: api/TourGuideServiceComments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TourGuideServiceComment>> DeleteTourGuideServiceComment(Guid id)
        {
            var tourGuideServiceComment = await _context.TourGuideServiceComments.FindAsync(id);
            if (tourGuideServiceComment == null)
            {
                return NotFound();
            }

            _context.TourGuideServiceComments.Remove(tourGuideServiceComment);
            await _context.SaveChangesAsync();

            return tourGuideServiceComment;
        }

        private bool TourGuideServiceCommentExists(Guid id)
        {
            return _context.TourGuideServiceComments.Any(e => e.ID == id);
        }
    }
}
