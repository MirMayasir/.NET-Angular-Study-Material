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
    public class FlightBookingsController : ControllerBase
    {
        private readonly FlightDatabaseContext _context;

        public FlightBookingsController(FlightDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/FlightBookings
        [HttpGet]
        public async Task<ActionResult<List<FlightBooking>>> GetFlightBookings()
        {
            return await _context.FlightBookings.ToListAsync();
        }

        // GET: api/FlightBookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FlightBooking>> GetFlightBooking(int id)
        {
            var flightBooking = await _context.FlightBookings.FindAsync(id);

            if (flightBooking == null)
            {
                return NotFound();
            }

            return flightBooking;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlightBooking(int id, FlightBooking flightBooking)
        {
            if (id != flightBooking.BookingId)
            {
                return BadRequest();
            }

            _context.Entry(flightBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightBookingExists(id))
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

        // POST: api/FlightBookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FlightBooking>> PostFlightBooking(FlightBooking flightBooking)
        {
            _context.FlightBookings.Add(flightBooking);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FlightBookingExists(flightBooking.BookingId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFlightBooking", new { id = flightBooking.BookingId }, flightBooking);
        }

        // DELETE: api/FlightBookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlightBooking(int id)
        {
            var flightBooking = await _context.FlightBookings.FindAsync(id);
            if (flightBooking == null)
            {
                return NotFound();
            }

            _context.FlightBookings.Remove(flightBooking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FlightBookingExists(int id)
        {
            return _context.FlightBookings.Any(e => e.BookingId == id);
        }
    }
}
