using System;
using System.Collections.Generic;

namespace FirstAPI.Models;

public partial class Course
{
    public int Cid { get; set; }

    public string? Cname { get; set; }

    public double? Fees { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
