using System;
using System.Collections.Generic;

namespace FirstAPI.Models;

public partial class Student
{
    public int Sid { get; set; }

    public string Sname { get; set; } = null!;

    public int? Age { get; set; }

    public double? Marks { get; set; }

    public bool? Result { get; set; }

    public int? Courseid { get; set; }

    public virtual Course? Course { get; set; }
}
