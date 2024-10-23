using System;
using System.Collections.Generic;

namespace AngularDemo.Models;

public partial class Employee
{
    public int Eid { get; set; }

    public string Ename { get; set; } = null!;

    public string? Esalary { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
