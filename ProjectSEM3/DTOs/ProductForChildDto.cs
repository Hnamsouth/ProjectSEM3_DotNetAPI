using System;
using ProjectSEM3.Entities;

namespace ProjectSEM3.DTOs
{
	public class ProductForChildDto
	{
        public int Id { get; set; }

        public int MinAge { get; set; }

        public int MaxAge { get; set; }

        public int? ProductId { get; set; }

        public virtual Product? Product { get; set; }
    }
}

