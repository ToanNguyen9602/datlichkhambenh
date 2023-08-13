using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Benhnhan
{
    public int Mabn { get; set; }

    public string Tenbn { get; set; } = null!;

    public DateTime? Ngaysinh { get; set; }

    public string? Gioitinh { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<Lichkham> Lichkhams { get; set; } = new List<Lichkham>();

    public virtual User? User { get; set; }
}
