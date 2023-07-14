using System;
using System.Collections.Generic;

namespace ProjectSEM3.Entities;

public partial class UserInfo
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public DateTime? Birthday { get; set; }

    public string? Country { get; set; }

    public bool? Gender { get; set; }

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}
