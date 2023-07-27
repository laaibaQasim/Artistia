using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace WebApplication1.Models;

public partial class Cart
{
    public int ImageId { get; set; }

    public int UserId { get; set; }

    public int Quantity { get; set; }

    public double Price { get; set; }

    public virtual Image Image { get; set; } = null!;

    public virtual UserData User { get; set; } = null!;
}
