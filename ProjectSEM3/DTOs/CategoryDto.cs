using ProjectSEM3.Entities;

namespace ProjectSEM3.DTOs
{
    public class CategoryDto
    {
        public int? Id { get; set; }

        public string Name { get; set; } = null!;

        public virtual List<Product>? Products { get; set; } = new List<Product>();
    }
}
