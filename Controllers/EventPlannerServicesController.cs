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
    public class EventPlannerServicesController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public EventPlannerServicesController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: api/EventPlannerServices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventPlannerService>>> GetEventPlannerServices(int? eventValue)
        {
            var events = _context.EventPlannerServices.AsQueryable();
            if (eventValue != null)
            {
                events = _context.EventPlannerServices.Where(i => i.Price < eventValue);
            }
            return await events.ToListAsync();
        }

        [HttpGet("Res")]
        public async Task<ActionResult<IEnumerable<EventPlannerService>>> GetNonEventPlannerServices(DateTime? arrival, DateTime? departure)
        {


            if ((arrival != null) && (departure != null))
            {
                var events = _context.EventPlannerServices.FromSqlInterpolated($"SELECT * from EventPlannerServices WHERE ID NOT IN ( SELECT EventPlannerServiceID as ID FROM   EventPlannerServices T JOIN Reservations R ON T.ID = R.EventPlannerServiceID WHERE(checkIn <= {arrival} AND checkOut >= {arrival}) OR (checkIn < {departure} AND checkOut >= {departure}) OR ({arrival} <= checkIn AND {departure} >= checkIn))").ToList();

                return events;
            }
            else
            {
                return NotFound();
            }


        }

        [HttpGet("SugDefault")]
        public async Task<ActionResult<IEnumerable<EventPlannerService>>> GetSuggestorDefaultEventPlannerServices(DateTime? arrival, DateTime? departure, int? eventValue)
        {


            if ((arrival != null) && (departure != null) && (eventValue != null))
            {
                var events = _context.EventPlannerServices.FromSqlInterpolated($"SELECT * from EventPlannerServices WHERE Price<={eventValue} AND ID NOT IN ( SELECT EventPlannerServiceID as ID FROM   EventPlannerServices T JOIN Reservations R ON T.ID = R.EventPlannerServiceID WHERE(checkIn <= {arrival} AND checkOut >= {arrival}) OR (checkIn < {departure} AND checkOut >= {departure}) OR ({arrival} <= checkIn AND {departure} >= checkIn))").ToList();

                return events;
            }
            else
            {
                return NotFound();
            }


        }

        [HttpGet("Sug")]
        public async Task<ActionResult<IEnumerable<EventPlannerService>>> GetSuggestorEventPlannerServices(DateTime? arrival, DateTime? departure, int? eventValue, string? hashtag)
        {


            if ((arrival != null) && (departure != null) && (eventValue != null) && (hashtag != null))
            {


                var events = _context.EventPlannerServices.FromSqlInterpolated($"SELECT* FROM PostHashTags P JOIN (SELECT * FROM EventPlannerServices WHERE Price<={eventValue} AND ID NOT IN ( SELECT EventPlannerServiceID as ID FROM   EventPlannerServices T JOIN Reservations R ON T.ID = R.EventPlannerServiceID WHERE(checkIn <= {arrival} AND checkOut >= {arrival}) OR (checkIn < {departure} AND checkOut >= {departure}) OR ({arrival} <= checkIn AND {departure} >= checkIn))) as ff ON P.EventPlannerServiceID = ff.ID WHERE P.HashTagID = {hashtag}").ToList();
               
                if(events==null)
                {
                    events = _context.EventPlannerServices.FromSqlInterpolated($"SELECT * from EventPlannerServices WHERE Price<={eventValue} AND ID NOT IN ( SELECT EventPlannerServiceID as ID FROM   EventPlannerServices T JOIN Reservations R ON T.ID = R.EventPlannerServiceID WHERE(checkIn <= {arrival} AND checkOut >= {arrival}) OR (checkIn < {departure} AND checkOut >= {departure}) OR ({arrival} <= checkIn AND {departure} >= checkIn))").ToList();
                    return events;
                }
                else
                {
                    return events;
                }   
            }
            else
            {
                return NotFound();
            }


        }


        [HttpGet("Hash")]
        public async Task<ActionResult<IEnumerable<EventPlannerService>>> GetSuggestorEventPlannerServiceswithHashTags(string? hashtag)
        {
            var events = _context.EventPlannerServices
                                    .Include(u => u.PostHashTags)
                                        .ThenInclude(e => e.HashTag)
                                    .ToList();

            if (events == null)
            {
                return NotFound();
            }

            return events;
        }

        // GET: api/EventPlannerServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventPlannerService>> GetEventPlannerService(Guid id)
        {
            var eventPlannerService = await _context.EventPlannerServices.FindAsync(id);

            if (eventPlannerService == null)
            {
                return NotFound();
            }

            return eventPlannerService;
        }

        [HttpGet("GetEventDetails/{id}")]
        public async Task<ActionResult<EventPlannerService>> GetEventPlannerServiceDetails(Guid id)
        {
            var eventPlannerService = await _context.EventPlannerServices
                                                     .Include(eve => eve.PostHashTags)
                                                        .ThenInclude(eve => eve.HashTag)
                                                    .Include(eve => eve.EventPlannerServiceComments)
                                                        .ThenInclude(eve => eve.User)
                                                     .Where(eve => eve.ID == id)
                                                     .FirstOrDefaultAsync();

            if (eventPlannerService == null)
            {
                return NotFound();
            }

            return eventPlannerService;
        }


        // PUT: api/EventPlannerServices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventPlannerService(Guid id, EventPlannerService eventPlannerService)
        {
            if (id != eventPlannerService.ID)
            {
                return BadRequest();
            }

            _context.Entry(eventPlannerService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventPlannerServiceExists(id))
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

        // POST: api/EventPlannerServices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EventPlannerService>> PostEventPlannerService(EventPlannerService eventPlannerService)
        {
            _context.EventPlannerServices.Add(eventPlannerService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventPlannerService", new { id = eventPlannerService.ID }, eventPlannerService);
        }

        // DELETE: api/EventPlannerServices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EventPlannerService>> DeleteEventPlannerService(Guid id)
        {
            var eventPlannerService = await _context.EventPlannerServices.FindAsync(id);
            if (eventPlannerService == null)
            {
                return NotFound();
            }

            _context.EventPlannerServices.Remove(eventPlannerService);
            await _context.SaveChangesAsync();

            return eventPlannerService;
        }

        private bool EventPlannerServiceExists(Guid id)
        {
            return _context.EventPlannerServices.Any(e => e.ID == id);
        }
    }
}