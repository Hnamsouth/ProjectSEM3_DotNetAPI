namespace ProjectSEM3.DTOs.Auth
{
    public class CdnItem
    {
        public string? asset_id { get; set; }
        public string? public_id { get; set; }
        public string? format { get; set; }
        public int? version { get; set; }
        public string? resource_type { get; set; }
        public string? type { get; set; }
        public string? created_at { get; set; }
        public int? bytes { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
        public string? folder { get; set; }
        public string? access_mode { get; set; }
        public string? url { get; set; }
        public string? secure_url { get; set; }
    }
}
