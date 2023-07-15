using ProjectSEM3.Entities;

namespace ProjectSEM3.DTOs
{
    public class SizeDto
    {

        public int? Id { get; set; }

        public string Name { get; set; } = null!;

        public virtual List<ProductSize> ProductSizes { get; set; } = new List<ProductSize>();
    }
}
