using System;
using System.Collections.Generic;

namespace CapstoneProjectAPI.Models;

public partial class Subscription
{
    public int SubscriptionId { get; set; }

    public string Username { get; set; } = null!;

    public bool? IsSubscribed { get; set; }

    public DateOnly? SubscriptionDate { get; set; }

    public DateOnly? UnsubscribeDate { get; set; }

    public string? PlanType { get; set; }
}
