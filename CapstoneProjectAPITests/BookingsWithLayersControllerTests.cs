using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using CapstoneProjectAPI.Controllers;
using CapstoneProjectAPI.Models;
using CapstoneProjectAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneProjectAPITests
{
    [TestFixture]
    public class BookingsWithLayersControllerTests
    {
        private Mock<IBookingService> _mockBookingService;
        private BookingsWithLayersController _controller;

        [SetUp]
        public void Setup()
        {
            // Initialize the mock service
            _mockBookingService = new Mock<IBookingService>();

            // Inject the mock service into the controller
            _controller = new BookingsWithLayersController(_mockBookingService.Object);
        }

        [Test]
        public async Task GetBookingByName_ReturnsOkResult_WithBookings()
        {
            // Arrange
            string customerName = "JohnDoe";
            var bookings = new List<Booking>
            {
                new Booking { BookingId = 1, CustomerName = "JohnDoe" },
                new Booking { BookingId = 2, CustomerName = "JohnDoe" }
            };

            _mockBookingService.Setup(service => service.GetBookingsByCustomerNameAsync(customerName)).ReturnsAsync(bookings);

            // Act
            var result = await _controller.GetBookingByName(customerName);

            // Assert: Ensure result is not null and is of the correct type
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ActionResult<IEnumerable<Booking>>>(result);

            // Assert: Ensure we get an OkObjectResult with the correct bookings
            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult, "Expected OkObjectResult");
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(bookings, okResult.Value);
        }
    }
}
