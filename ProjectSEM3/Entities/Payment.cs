using System;
using System.Collections.Generic;

namespace ProjectSEM3.Entities;

public partial class Payment
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int PostalCode { get; set; }

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int? OrderId { get; set; }

    public int? UserId { get; set; }

    public virtual Order? Order { get; set; }

    public virtual User? User { get; set; }
}
