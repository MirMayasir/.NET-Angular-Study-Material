using System;
using System.Collections.Generic;

namespace ScoreManagmentAPI.Models;

public partial class Team
{
    public int TeamId { get; set; }

    public string Name { get; set; } = null!;

    public int? SportId { get; set; }

    public virtual Sport? Sport { get; set; }
}
