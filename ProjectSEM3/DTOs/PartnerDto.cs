using System;
using ProjectSEM3.Entities;

namespace ProjectSEM3.DTOs
{
	public class PartnerDto
	{
        public int Id { get; set; }

        public string RepresentativeName { get; set; } = null!;

        public bool Type { get; set; } //1: personal, 2: company

        public bool Status { get; set; } //1: cooperating, 2: stop cooperating

        public string? Description { get; set; }

        public virtual ICollection<AdCampaign> AdCampaigns { get; set; } = new List<AdCampaign>();

        public virtual ICollection<PartnersInfo> PartnersInfos { get; set; } = new List<PartnersInfo>();
    }
}

