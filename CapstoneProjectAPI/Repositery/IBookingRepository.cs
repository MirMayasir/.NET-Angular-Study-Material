using CapstoneProjectAPI.Models;

namespace CapstoneProjectAPI.Repositery
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetAllBookingsAsync();
        Task<Booking> GetBookingByIdAsync(int id);
        Task AddBookingAsync(Booking booking);
        Task<IEnumerable<Booking>> GetBookingsByCustomerNameAsync(string customerName);
    }
}
