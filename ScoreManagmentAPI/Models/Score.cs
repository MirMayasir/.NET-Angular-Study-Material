using System;
using System.Collections.Generic;

namespace ScoreManagmentAPI.Models;

public partial class Score
{
    public int ScoreId { get; set; }

    public int MatchId { get; set; }

    public int Team1Score { get; set; }

    public int Team2Score { get; set; }

    public DateTime LastUpdated { get; set; }

    public virtual Match Match { get; set; } = null!;
}
