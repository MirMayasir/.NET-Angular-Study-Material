using System;
using System.Collections.Generic;

namespace MySQLwebAPI.Model;

public partial class Employee
{
    public int Eid { get; set; }

    public string? Ename { get; set; }

    public string? Esalary { get; set; }
}
