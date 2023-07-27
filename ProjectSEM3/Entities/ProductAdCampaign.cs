using System;
using System.Collections.Generic;

namespace ProjectSEM3.Entities;

public partial class ProductAdCampaign
{
    public int? ProductId { get; set; }

    public int? AdcampaignId { get; set; }

    public virtual AdCampaign? Adcampaign { get; set; }

    public virtual Product? Product { get; set; }
}
