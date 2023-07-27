using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Image
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Height { get; set; }

    public int Width { get; set; }

    public string Category { get; set; } = null!;

    public int OwnerId { get; set; }

    public double Price { get; set; }

    public string ImgLink { get; set; } = null!;

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Owner Owner { get; set; } = null!;
}
