using Moq;
using NUnit.Framework;
using CapstoneProjectAPI.Models;
using CapstoneProjectAPI.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapstoneProjectAPI.Repositery;

namespace CapstoneProjectAPITests
{
    [TestFixture]
    public class BookingServiceTests
    {
        private Mock<IBookingRepository> _mockRepository;
        private BookingService _service;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IBookingRepository>();
            _service = new BookingService(_mockRepository.Object);
        }

        [Test]
        public async Task GetBookingsByCustomerNameAsync_ShouldReturnBookings()
        {
            // Arrange
            var bookings = new List<Booking>
            {
                new Booking { BookingId = 1, CustomerName = "JohnDoe" },
                new Booking { BookingId = 2, CustomerName = "JohnDoe" }
            };

            _mockRepository.Setup(repo => repo.GetBookingsByCustomerNameAsync("JohnDoe"))
                .ReturnsAsync(bookings);

            // Act
            var result = await _service.GetBookingsByCustomerNameAsync("JohnDoe");

            // Assert
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public async Task GetBookingByIdAsync_ShouldReturnBooking()
        {
            // Arrange
            var booking = new Booking { BookingId = 1, CustomerName = "JaneDoe" };

            _mockRepository.Setup(repo => repo.GetBookingByIdAsync(1))
                .ReturnsAsync(booking);

            // Act
            var result = await _service.GetBookingByIdAsync(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("JaneDoe", result.CustomerName);
        }
    }
}
