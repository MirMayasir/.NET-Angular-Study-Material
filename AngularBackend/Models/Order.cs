using System;
using System.Collections.Generic;

namespace AngularDemo.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public string? Orderdisc { get; set; }

    public int OrderNumber { get; set; }

    public int? EmpId { get; set; }

    public virtual Employee? Emp { get; set; }
}
