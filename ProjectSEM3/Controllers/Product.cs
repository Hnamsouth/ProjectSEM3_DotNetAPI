using ProjectSEM3.Entities;

namespace ProjectSEM3.Controllers
{
    public class Product
    {
        public int Id { get; set; }

        public string Img { get; set; } = null!;

        public string? ColorName { get; set; }

        public int? ProductId { get; set; }

        public virtual List<ProductColor>? Products { get; set; } = new List<ProductColor>();
       

    }
}
