using System;
using System.Collections.Generic;

namespace ScoreManagmentAPI.Models;

public partial class Event
{
    public int EventId { get; set; }

    public int MatchId { get; set; }

    public string EventType { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime Timestamp { get; set; }

    public virtual Match Match { get; set; } = null!;
}
