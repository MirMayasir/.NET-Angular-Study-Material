using System;
using System.Collections.Generic;

namespace AppontmentManagement.Models;

public partial class FlightBooking
{
    public int BookingId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string FlightFrom { get; set; } = null!;

    public string FlightTo { get; set; } = null!;

    public DateOnly DepartureDate { get; set; }

    public DateOnly? ArrivalDate { get; set; }

    public string? FlightClass { get; set; }

    public DateTime? CreatedAt { get; set; }

    public decimal? Price { get; set; }
}
