using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Bacsi
{
    public int Mabs { get; set; }

    public string Tenbs { get; set; } = null!;

    public DateTime? Ngaysinh { get; set; }

    public int Makhoa { get; set; }

    public virtual ICollection<Lichkham> Lichkhams { get; set; } = new List<Lichkham>();

    public virtual Khoa Khoa { get; set; } = null!;

   
}
