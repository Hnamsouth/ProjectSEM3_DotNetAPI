using System;
using System.Collections.Generic;

namespace ProjectSEM3.Entities;

public partial class Order
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public byte Status { get; set; }

    public int? UserId { get; set; }

    public string Firstname { get; set; } = null!;

    public string Laststname { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string City { get; set; } = null!;

    public string District { get; set; } = null!;

    public int Postcode { get; set; }

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string DeliveryMethod { get; set; } = null!;

    public string Country { get; set; } = null!;

    public int? VoucherId { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual User? User { get; set; }

    public virtual Voucher? Voucher { get; set; }
}
