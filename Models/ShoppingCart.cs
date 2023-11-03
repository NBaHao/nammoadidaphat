﻿using System;
using System.Collections.Generic;

namespace WebApplication1.Entities;

public partial class ShoppingCart
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();

    public virtual SiteUser? User { get; set; }
}
