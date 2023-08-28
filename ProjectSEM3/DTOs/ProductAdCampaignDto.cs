using System;
using ProjectSEM3.Entities;

namespace ProjectSEM3.DTOs
{
    public class ProductAdCampaignDto
    {
        public int? ProductId { get; set; }

        public int? AdcampaignId { get; set; }

        public virtual AdCampaign? Adcampaign { get; set; }

        public virtual Product? Product { get; set; }
    }
}

