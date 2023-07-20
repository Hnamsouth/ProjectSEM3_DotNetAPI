using System;
using System.Collections.Generic;

namespace ProjectSEM3.Entities;

public partial class News
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string ShortDescription { get; set; } = null!;

    public string Thumbnail { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public int? AdminId { get; set; }

    public virtual Admin? Admin { get; set; }
}
