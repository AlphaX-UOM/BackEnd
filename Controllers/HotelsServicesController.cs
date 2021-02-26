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
    public class HotelsServicesController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public HotelsServicesController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: api/HotelsServices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelsService>>> GetHotelsServices(int? hotelValue)
        {
            var hotel = _context.HotelsServices.AsQueryable();
            if(hotelValue != null)
            {
                hotel = _context.HotelsServices.Where(i => i.PricePerDay < hotelValue);
            }
            return await hotel.ToListAsync();
        }

        [HttpGet("Res")]
        public async Task<ActionResult<IEnumerable<HotelsService>>> GetNonHotelsServices(DateTime? arrival, DateTime? departure)
        {


            if ((arrival != null) && (departure != null))
            {
                var hotel = _context.HotelsServices.FromSqlInterpolated($"SELECT * from HotelsServices WHERE ID NOT IN ( SELECT HotelsServiceID as ID FROM   HotelsServices T JOIN Reservations R ON T.ID = R.HotelsServiceID WHERE(checkIn <= {arrival} AND checkOut >= {arrival}) OR (checkIn < {departure} AND checkOut >= {departure}) OR ({arrival} <= checkIn AND {departure} >= checkIn))").ToList();

                return hotel;
            }
            else
            {
                return NotFound();
            }


        }

        [HttpGet("Sug")]
        public async Task<ActionResult<IEnumerable<HotelsService>>> GetSuggestorHotelsServices(DateTime? arrival, DateTime? departure, int? hotelValue)
        {


            if ((arrival != null) && (departure != null) && (hotelValue != null))
            {
                var hotel = _context.HotelsServices.FromSqlInterpolated($"SELECT * from HotelsServices WHERE PricePerDay<={hotelValue} AND ID NOT IN ( SELECT HotelsServiceID as ID FROM   HotelsServices T JOIN Reservations R ON T.ID = R.HotelsServiceID WHERE(checkIn <= {arrival} AND checkOut >= {arrival}) OR (checkIn < {departure} AND checkOut >= {departure}) OR ({arrival} <= checkIn AND {departure} >= checkIn))").ToList();

                return hotel;
            }
            else
            {
                return NotFound();
            }


        }

        // GET: api/HotelsServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelsService>> GetHotelsService(Guid id)
        {
            var hotelsService = await _context.HotelsServices.FindAsync(id);

            if (hotelsService == null)
            {
                return NotFound();
            }

            return hotelsService;
        }

        // PUT: api/HotelsServices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelsService(Guid id, HotelsService hotelsService)
        {
            if (id != hotelsService.ID)
            {
                return BadRequest();
            }

            _context.Entry(hotelsService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelsServiceExists(id))
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

        // POST: api/HotelsServices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HotelsService>> PostHotelsService(HotelsService hotelsService)
        {
            _context.HotelsServices.Add(hotelsService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotelsService", new { id = hotelsService.ID }, hotelsService);
        }

        // DELETE: api/HotelsServices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HotelsService>> DeleteHotelsService(Guid id)
        {
            var hotelsService = await _context.HotelsServices.FindAsync(id);
            if (hotelsService == null)
            {
                return NotFound();
            }

            _context.HotelsServices.Remove(hotelsService);
            await _context.SaveChangesAsync();

            return hotelsService;
        }

        private bool HotelsServiceExists(Guid id)
        {
            return _context.HotelsServices.Any(e => e.ID == id);
        }
    }
}
