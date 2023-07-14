using System;
using System.Collections.Generic;

namespace ProjectSEM3.Entities;

public partial class Favoury
{
    public int Id { get; set; }

    public int? ProductColorId { get; set; }

    public int? ProductId { get; set; }

    public int? UserId { get; set; }

    public virtual Product? Product { get; set; }

    public virtual ProductColor? ProductColor { get; set; }

    public virtual User? User { get; set; }
}
