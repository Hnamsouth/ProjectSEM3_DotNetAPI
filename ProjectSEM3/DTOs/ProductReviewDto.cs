using System;
using ProjectSEM3.Entities;

namespace ProjectSEM3.DTOs
{
	public class ProductReviewDto
	{
        public int Id { get; set; }

        public string? Comment { get; set; }

        public int Rate { get; set; }

        public int? ProductId { get; set; }

        public int? UserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual Product? Product { get; set; }

        public virtual User? User { get; set; }
    }
}

