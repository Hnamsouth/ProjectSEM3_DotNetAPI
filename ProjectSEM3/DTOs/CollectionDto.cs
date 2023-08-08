using System;
using ProjectSEM3.Entities;

namespace ProjectSEM3.DTOs
{
	public class CollectionDto
	{
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public virtual ICollection<AdCampaign> AdCampaigns { get; set; } = new List<AdCampaign>();
    }
}

