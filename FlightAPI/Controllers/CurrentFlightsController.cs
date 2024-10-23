using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlightAPI.Models;

namespace FlightAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrentFlightsController : ControllerBase
    {
        private readonly FlightDatabaseContext _context;

        public CurrentFlightsController(FlightDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/CurrentFlights
        [HttpGet]
        public async Task<ActionResult<List<CurrentFlight>>> GetCurrentFlights()
        {
            return Ok(await _context.CurrentFlights.ToListAsync());
        }


        // GET: api/CurrentFlights/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CurrentFlight>> GetCurrentFlightById(int id)
        {
            var a = _context.CurrentFlights.Where(x => x.BookingId == id).SingleOrDefault();
            return Ok(a);
        }

        // POST: api/CurrentFlights
        [HttpPost]
        public async Task<ActionResult<CurrentFlight>> AddFlight(CurrentFlight c)
        {
            if(ModelState.IsValid)
            {
                _context.CurrentFlights.Add(c);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE: api/CurrentFlights/5
        [HttpDelete("{id}")]
        
        public async Task<ActionResult<CurrentFlight>> deleteFlight(int id)
        {
            if(ModelState.IsValid)
            {
                CurrentFlight c = await _context.CurrentFlights.FindAsync(id);
                _context.CurrentFlights.Remove(c);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        private bool CurrentFlightExists(int id)
        {
            return _context.CurrentFlights.Any(e => e.BookingId == id);
        }
    }
}
