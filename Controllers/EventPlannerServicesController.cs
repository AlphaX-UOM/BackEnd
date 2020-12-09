﻿using System;
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
        public async Task<ActionResult<IEnumerable<EventPlannerService>>> GetEventPlannerServices()
        {
            return await _context.EventPlannerServices.ToListAsync();
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