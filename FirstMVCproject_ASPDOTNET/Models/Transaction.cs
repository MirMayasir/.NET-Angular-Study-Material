using System;
using System.Collections.Generic;

namespace FirstMVCproject.Models;

public partial class Transaction
{
    public string Tnumber { get; set; } = null!;

    public string Tanumber { get; set; } = null!;

    public DateOnly? Tdate { get; set; }

    public decimal Tammount { get; set; }
}
