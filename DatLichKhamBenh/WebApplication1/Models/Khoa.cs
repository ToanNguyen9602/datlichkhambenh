using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Khoa
{
    public int Makhoa { get; set; }

    public string Tenkhoa { get; set; } = null!;

    public virtual ICollection<Bacsi> Bacsis { get; set; } = new List<Bacsi>();
}
