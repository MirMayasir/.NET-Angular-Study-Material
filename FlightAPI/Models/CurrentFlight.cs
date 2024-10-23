using System;
using System.Collections.Generic;

namespace FlightAPI.Models;

public partial class CurrentFlight
{
    public string FlightFrom { get; set; } = null!;

    public string FlightTo { get; set; } = null!;

    public DateOnly DepartureDate { get; set; }

    public DateOnly ReturnDate { get; set; }

    public string FlightClass { get; set; } = null!;

    public int BookingId { get; set; }

    public decimal Price { get; set; }

    public string? CustomerName { get; set; }
}
