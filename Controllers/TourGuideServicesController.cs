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
    public class TourGuideServicesController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public TourGuideServicesController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: api/TourGuideServices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TourGuideService>>> GetTourGuideServices(int? guideValue)
        {
            var guide = _context.TourGuideServices.AsQueryable();
            if(guideValue != null)
            {
                guide = _context.TourGuideServices.Where(i => i.CostPerDay < guideValue);
            }

            return await guide.ToListAsync();
        }

        [HttpGet("Res")]
        public async Task<ActionResult<IEnumerable<TourGuideService>>> GetNonTourGuideServices(DateTime? arrival, DateTime? departure)
        {


            if ((arrival != null) && (departure != null))
            {
                var guide = _context.TourGuideServices.FromSqlInterpolated($"SELECT * from TourGuideServices WHERE ID NOT IN ( SELECT TourGuideServiceID as ID FROM   TourGuideServices T JOIN Reservations R ON T.ID = R.TourGuideServiceID WHERE(checkIn <= {arrival} AND checkOut >= {arrival}) OR (checkIn < {departure} AND checkOut >= {departure}) OR ({arrival} <= checkIn AND {departure} >= checkIn))").ToList();

                return guide;
            }
            else
            {
                return NotFound();
            }


        }

        [HttpGet("Sug")]
        public async Task<ActionResult<IEnumerable<TourGuideService>>> GetSuggestorTourGuideServices(DateTime? arrival, DateTime? departure, int? guideValue)
        {


            if ((arrival != null) && (departure != null) && (guideValue != null))
            {
                var guide = _context.TourGuideServices.FromSqlInterpolated($"SELECT * from TourGuideServices WHERE CostPerDay<={guideValue} AND ID NOT IN ( SELECT TourGuideServiceID as ID FROM   TourGuideServices T JOIN Reservations R ON T.ID = R.TourGuideServiceID WHERE(checkIn <= {arrival} AND checkOut >= {arrival}) OR (checkIn < {departure} AND checkOut >= {departure}) OR ({arrival} <= checkIn AND {departure} >= checkIn))").ToList();

                return guide;
            }
            else
            {
                return NotFound();
            }


        }

        // GET: api/TourGuideServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TourGuideService>> GetTourGuideService(Guid id)
        {
            var tourGuideService = await _context.TourGuideServices.FindAsync(id);

            if (tourGuideService == null)
            {
                return NotFound();
            }

            return tourGuideService;
        }

        // PUT: api/TourGuideServices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTourGuideService(Guid id, TourGuideService tourGuideService)
        {
            if (id != tourGuideService.ID)
            {
                return BadRequest();
            }

            _context.Entry(tourGuideService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourGuideServiceExists(id))
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

        // POST: api/TourGuideServices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TourGuideService>> PostTourGuideService(TourGuideService tourGuideService)
        {
            _context.TourGuideServices.Add(tourGuideService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTourGuideService", new { id = tourGuideService.ID }, tourGuideService);
        }

        // DELETE: api/TourGuideServices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TourGuideService>> DeleteTourGuideService(Guid id)
        {
            var tourGuideService = await _context.TourGuideServices.FindAsync(id);
            if (tourGuideService == null)
            {
                return NotFound();
            }

            _context.TourGuideServices.Remove(tourGuideService);
            await _context.SaveChangesAsync();

            return tourGuideService;
        }

        private bool TourGuideServiceExists(Guid id)
        {
            return _context.TourGuideServices.Any(e => e.ID == id);
        }
    }
}
