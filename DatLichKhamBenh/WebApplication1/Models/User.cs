using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool Role { get; set; }

    public virtual ICollection<Benhnhan> Benhnhans { get; set; } = new List<Benhnhan>();
}
