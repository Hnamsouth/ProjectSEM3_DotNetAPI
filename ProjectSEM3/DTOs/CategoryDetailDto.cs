using System;
using ProjectSEM3.Entities;

namespace ProjectSEM3.DTOs
{
    public class CategoryDetailDto
    {
        public int? Id { get; set; }

        public string Name { get; set; } = null!;

        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        public virtual ICollection<Product>? Products { get; set; } = new List<Product>();

    }
}

