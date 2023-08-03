using System;
using ProjectSEM3.Entities;

namespace ProjectSEM3.DTOs
{
	public class DiscountProductDto
	{
        public int Id { get; set; }

        public int? ProductId { get; set; }

        public int? DiscountId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public virtual Discount? Discount { get; set; }

        public virtual Product? Product { get; set; }
    }
}

