using System;
using System.Collections.Generic;

namespace ProjectSEM3.Entities;

public partial class ProductColorImage
{
    public int Id { get; set; }

    public string? Url { get; set; }

    public string? PublicId { get; set; }

    public string? Folder { get; set; }

    public string? AssetId { get; set; }

    public int? ProductColorId { get; set; }

    public virtual ProductColor? ProductColor { get; set; }
}
