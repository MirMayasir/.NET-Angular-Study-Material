using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlightAPI.Models;

public partial class Contactu
{
    [Required(ErrorMessage = "required")]
    public string FullName { get; set; } = null!;

    public string? Email { get; set; }

    public string? Contact { get; set; }

    public string? Message { get; set; }
}
