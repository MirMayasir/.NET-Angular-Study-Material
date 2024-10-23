using System;
using System.Collections.Generic;

namespace AppontmentManagement.Models;

public partial class User
{
    public string UserName { get; set; } = null!;

    public string? Password { get; set; }
}
