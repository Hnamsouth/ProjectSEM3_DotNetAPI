using System;
using ProjectSEM3.Entities;

namespace ProjectSEM3.DTOs
{
	public class PartnersInfoDto
	{
        public int Id { get; set; }

        public string Phone { get; set; } = null!;

        public string? CompanyName { get; set; }

        public string? Address { get; set; }

        public string? Img { get; set; }

        public int? PartnersId { get; set; }

        public virtual Partner? Partners { get; set; }
    }
}

