namespace ProjectSEM3.DTOs
{
    public class ProductColorUpdate
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int? ProductId { get; set; }
        public List<string>? Img { get; set; }
    }
}
