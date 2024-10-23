using CapstoneProjectAPI.Models;
using CapstoneProjectAPI.Repositery;

namespace CapstoneProjectAPI.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            return await _bookingRepository.GetAllBookingsAsync();
        }

        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            return await _bookingRepository.GetBookingByIdAsync(id);
        }

        public async Task AddBookingAsync(Booking booking)
        {
            await _bookingRepository.AddBookingAsync(booking);
        }

        public async Task<IEnumerable<Booking>> GetBookingsByCustomerNameAsync(string customerName)
        {
            return await _bookingRepository.GetBookingsByCustomerNameAsync(customerName);
        }
    }
}
