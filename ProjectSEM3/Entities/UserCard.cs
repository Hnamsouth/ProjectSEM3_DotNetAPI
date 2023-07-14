using System;
using System.Collections.Generic;

namespace ProjectSEM3.Entities;

public partial class UserCard
{
    public int CardNumber { get; set; }

    public string NameOnCard { get; set; } = null!;

    public string ExpiryDate { get; set; } = null!;

    public byte Cvc { get; set; }

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}
