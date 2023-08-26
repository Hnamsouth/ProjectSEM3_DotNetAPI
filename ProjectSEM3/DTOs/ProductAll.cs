using ProjectSEM3.Entities;

namespace ProjectSEM3.DTOs
{
    public class ProductAll
    {
        public ProductAll(Product data)
        {
            Id = data.Id; Name = data.Name;Price = data.Price;Description = data.Description;Gender = data.Gender;OpenSale = data.OpenSale; Status = data.Status;
            CategoryDetail = new CategoryDetail
            {
                Id = data.CategoryDetail.Id,
                Name = data.CategoryDetail.Name,
                Category = data.CategoryDetail.Category
            };
            Kindofsport = data.Kindofsport;

        }

        public int? Id { get; set; }

        public string? Name { get; set; } = null!;

        public decimal? Price { get; set; }

        public string? Description { get; set; }

        public byte? Gender { get; set; }

        public DateTime? OpenSale { get; set; }

        public byte? Status { get; set; }

        public int? CategoryDetailId { get; set; }

        public int? KindofsportId { get; set; }

        public  Object? CategoryDetail { get; set; }
        public Object? Kindofsport { get; set; }
        public  ICollection<Object>? ProductColors { get; set; } = new List<Object>();

    }
}
