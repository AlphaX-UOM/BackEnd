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
    public class TransportServicesController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public TransportServicesController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: api/TransportServices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransportService>>> GetTransportServices()
        {
            return await _context.TransportServices.ToListAsync();
        }

        // GET: api/TransportServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransportService>> GetTransportService(Guid id)
        {
            var transportService = await _context.TransportServices.FindAsync(id);

            if (transportService == null)
            {
                return NotFound();
            }

            return transportService;
        }

        // PUT: api/TransportServices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransportService(Guid id, TransportService transportService)
        {
            if (id != transportService.ID)
            {
                return BadRequest();
            }

            _context.Entry(transportService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransportServiceExists(id))
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

        // POST: api/TransportServices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TransportService>> PostTransportService(TransportService transportService)
        {
            _context.TransportServices.Add(transportService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransportService", new { id = transportService.ID }, transportService);
        }

        // DELETE: api/TransportServices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TransportService>> DeleteTransportService(Guid id)
        {
            var transportService = await _context.TransportServices.FindAsync(id);
            if (transportService == null)
            {
                return NotFound();
            }

            _context.TransportServices.Remove(transportService);
            await _context.SaveChangesAsync();

            return transportService;
        }

        private bool TransportServiceExists(Guid id)
        {
            return _context.TransportServices.Any(e => e.ID == id);
        }
    }
}