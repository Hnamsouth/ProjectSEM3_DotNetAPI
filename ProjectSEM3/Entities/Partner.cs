using System;
using System.Collections.Generic;

namespace ProjectSEM3.Entities;

public partial class Partner
{
    public int Id { get; set; }

    public string RepresentativeName { get; set; } = null!;

    public bool Type { get; set; }

    public bool Status { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<AdCampaign>? AdCampaigns { get; set; } = new List<AdCampaign>();

    public virtual ICollection<PartnersInfo>? PartnersInfos { get; set; } = new List<PartnersInfo>();
}
