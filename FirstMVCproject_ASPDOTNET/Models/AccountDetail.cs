using System;
using System.Collections.Generic;

namespace FirstMVCproject.Models;

public partial class AccountDetail
{
    public string Anumber { get; set; } = null!;

    public string? Aname { get; set; }

    public string? Aaddress { get; set; }

    public decimal? Abalance { get; set; }
}
