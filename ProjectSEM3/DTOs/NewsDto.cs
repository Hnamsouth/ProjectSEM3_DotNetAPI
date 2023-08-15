using System;
using ProjectSEM3.Entities;

namespace ProjectSEM3.DTOs
{
	public class NewsDto
	{
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string ShortDescription { get; set; } = null!;

        public string Thumbnail { get; set; } = null!;

        public string Content { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public int? AdminId { get; set; }

        public virtual Admin? Admin { get; set; }
    }
}

