using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CapstoneProjectAPI.Models;

namespace CapstoneProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly CapstoneProjectContext _context;

        public BookingsController(CapstoneProjectContext context)
        {
            _context = context;
        }

        // GET: api/Bookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
            return await _context.Bookings.ToListAsync();
        }

        // GET: api/Bookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBooking(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);

            if (booking == null)
            {
                return NotFound();
            }

            return booking;
        }

        

        // POST: api/Bookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBooking", new { id = booking.BookingId }, booking);
        }

        

        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.BookingId == id);
        }

        // GET: api/Bookings/byname?customerName=JohnDoe
        [HttpGet("byname")]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookingByName([FromQuery] string customerName)
        {
            if (string.IsNullOrWhiteSpace(customerName))
            {
                return BadRequest("Customer name must be provided.");
            }

            // Convert customerName to lowercase
            string lowerCustomerName = customerName.ToLower();

            // Fetch bookings with case-insensitive comparison
            var bookings = await _context.Bookings
                .Where(b => b.CustomerName.ToLower() == lowerCustomerName)
                .ToListAsync();

            if (bookings == null || !bookings.Any())
            {
                return NotFound("No bookings found for the specified customer name.");
            }

            return Ok(bookings);
        }

    }
}
