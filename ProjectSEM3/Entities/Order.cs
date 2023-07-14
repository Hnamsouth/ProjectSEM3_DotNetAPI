using System;
using System.Collections.Generic;

namespace ProjectSEM3.Entities;

public partial class Order
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public byte Status { get; set; }

    public string? ShipCode { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual User? User { get; set; }
}
