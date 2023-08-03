using System;
using ProjectSEM3.Entities;

namespace ProjectSEM3.DTOs
{
	public class KindOfSportDto
	{
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}

