﻿using System;
using System.Collections.Generic;

namespace CoolMate.Models;

public partial class ShopOrder
{
    public int Id { get; set; }

    public String? UserId { get; set; }

    public DateTime? OrderDate { get; set; }

    public int? PaymentMethod { get; set; }

    public String? ShippingAddress { get; set; }
    public String? Name { get; set; } 
    public String? Phone { get; set; } 
    public String? Email { get; set; }

    public int? ShippingMethod { get; set; }

    public int? OrderTotal { get; set; }

    public int? OrderStatus { get; set; }

    public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

    public virtual SiteUser? User { get; set; }
}
