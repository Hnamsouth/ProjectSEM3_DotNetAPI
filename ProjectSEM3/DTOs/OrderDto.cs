using System;
using ProjectSEM3.Entities;

namespace ProjectSEM3.DTOs
{
	public class OrderDto
	{
        public int? Id { get; set; }

        public DateTime? Date { get; set; }

        public byte? Status { get; set; }

        public int? VoucherId { get; set; }

        public string Firstname { get; set; } = null!;

        public string Laststname { get; set; } = null!;
        public string Country { get; set; } = null!;

        public string Street { get; set; } = null!;

        public string City { get; set; } = null!;

        public string District { get; set; } = null!;

        public int Postcode { get; set; }

        public string Phone { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? DeliveryMethod { get; set; } = null!;

    }
}

