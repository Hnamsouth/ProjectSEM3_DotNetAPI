using System;
using System.Collections.Generic;

namespace ProjectSEM3.Entities;

public partial class Admin
{
    public int Id { get; set; }

    public string Role { get; set; } = null!;

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}
