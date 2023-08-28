using System;
using System.Collections.Generic;

namespace ProjectSEM3.Entities;

public partial class AdCampaign
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Img { get; set; } = null!;

    public string? Desciption { get; set; }

    public DateTime OpenDate { get; set; }

    public DateTime EndDate { get; set; }

    public int? PartnersId { get; set; }

    public int? CollectionId { get; set; }

    public virtual Collection? Collection { get; set; }

    public virtual Partner? Partners { get; set; }
}
