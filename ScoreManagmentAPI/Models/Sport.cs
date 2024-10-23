using System;
using System.Collections.Generic;

namespace ScoreManagmentAPI.Models;

public partial class Sport
{
    public int SportId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
