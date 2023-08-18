namespace ProjectSEM3.DTOs
{
    public class ProductColorCreate
    {
        public string? Name { get; set; }

        public int? ProductId { get; set; }
        public List<string> Img { get; set; }
        //public IFormFileCollection? Img { get; set; }
    }
}
