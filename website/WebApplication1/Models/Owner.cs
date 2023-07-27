using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Owner
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Details { get; set; } = null!;

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();
}
