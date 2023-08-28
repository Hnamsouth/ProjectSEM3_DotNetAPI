using System;
using ProjectSEM3.Entities;

namespace ProjectSEM3.DTOs
{
	public class OrderDto
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
}

