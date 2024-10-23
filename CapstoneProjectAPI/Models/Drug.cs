using System;
using System.Collections.Generic;

namespace CapstoneProjectAPI.Models;

public partial class Drug
{
    public int DrugId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Manufacturer { get; set; }

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public string? Region { get; set; }
}
