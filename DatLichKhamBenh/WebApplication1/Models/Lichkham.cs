using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Lichkham
{
    public int Id { get; set; }

    public int Mabs { get; set; }

    public int Mabn { get; set; }

    public DateTime Ngaykham { get; set; }

    public string Noidung { get; set; } = null!;

    public virtual Benhnhan Bennhan { get; set; } = null!;

    public virtual Bacsi Bacsi { get; set; } = null!;
}
