using System.Collections.Generic;
using System.Threading.Tasks;
using CapstoneProjectAPI.Models;
using CapstoneProjectAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsWithLayersController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingsWithLayersController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        // GET: api/BookingsWithLayers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
            var bookings = await _bookingService.GetAllBookingsAsync();
            return Ok(bookings);
        }

        // GET: api/BookingsWithLayers/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBooking(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }

        // POST: api/BookingsWithLayers
        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking(Booking booking)
        {
            await _bookingService.AddBookingAsync(booking);
            return CreatedAtAction(nameof(GetBooking), new { id = booking.BookingId }, booking);
        }

        [HttpGet("byname")]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookingByName([FromQuery] string customerName)
        {
            if (string.IsNullOrWhiteSpace(customerName))
            {
                return BadRequest("Customer name must be provided.");
            }

            var bookings = await _bookingService.GetBookingsByCustomerNameAsync(customerName);

            if (bookings == null || !bookings.Any()) // Using .Any() to check for empty collection
            {
                return NotFound("No bookings found for the specified customer name.");
            }

            return Ok(bookings);
        }

    }
}
