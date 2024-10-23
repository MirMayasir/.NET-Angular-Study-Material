using System;
using System.Collections.Generic;

namespace ScoreManagmentAPI.Models;

public partial class Match
{
    public int MatchId { get; set; }

    public string Team1 { get; set; } = null!;

    public string Team2 { get; set; } = null!;

    public string Sport { get; set; } = null!;

    public DateTime StartTime { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<Score> Scores { get; set; } = new List<Score>();
}
