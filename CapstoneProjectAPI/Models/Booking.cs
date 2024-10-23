using System;
using System.Collections.Generic;

namespace CapstoneProjectAPI.Models;

public partial class Booking
{
    public int BookingId { get; set; }

    public string DrugName { get; set; } = null!;

    public string? DrugDescription { get; set; }

    public string? Manufacturer { get; set; }

    public decimal Price { get; set; }

    public string? Region { get; set; }

    public string? CustomerName { get; set; }

    public int? DosagePeriod { get; set; }

    public DateOnly? BookDate { get; set; }
}
