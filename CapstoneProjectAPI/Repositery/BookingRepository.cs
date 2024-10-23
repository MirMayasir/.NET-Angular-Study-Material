using CapstoneProjectAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CapstoneProjectAPI.Repositery
{
    public class BookingRepository : IBookingRepository
    {
        private readonly CapstoneProjectContext _context;

        public BookingRepository(CapstoneProjectContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            return await _context.Bookings.ToListAsync();
        }

        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            return await _context.Bookings.FindAsync(id);
        }

        public async Task AddBookingAsync(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Booking>> GetBookingsByCustomerNameAsync(string customerName)
        {
            return await _context.Bookings
                .Where(b => b.CustomerName.ToLower() == customerName.ToLower())
                .ToListAsync();
        }
    }
}
