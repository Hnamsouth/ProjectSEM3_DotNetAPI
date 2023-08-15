using System;
namespace ProjectSEM3.DTOs
{
	public class VoucherDto
	{
        public int Id { get; set; }

        public string Coupon { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal? DiscountPercent { get; set; }

        public decimal? DiscountFlat { get; set; }

        public string Thumbnail { get; set; } = null!;

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}

