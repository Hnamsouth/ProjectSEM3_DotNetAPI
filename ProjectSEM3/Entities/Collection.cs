using System;
using System.Collections.Generic;

namespace ProjectSEM3.Entities;

public partial class Collection
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<AdCampaign> AdCampaigns { get; set; } = new List<AdCampaign>();
}
