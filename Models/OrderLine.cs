﻿using System;
using System.Collections.Generic;

namespace CoolMate.Models;

public partial class OrderLine
{
    public int Id { get; set; }

    public int? ProductItemId { get; set; }

    public int? OrderId { get; set; }

    public int? Qty { get; set; }

    public int? Price { get; set; }

    public virtual ShopOrder? Order { get; set; }

    public virtual ProductItem? ProductItem { get; set; }

}
