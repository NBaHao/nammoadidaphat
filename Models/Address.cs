﻿using System;
using System.Collections.Generic;

namespace CoolMate.Models;

public partial class Address
{
    public int Id { get; set; }

    public string? AddressLine { get; set; }

    public string? Province { get; set; }

    public string? District { get; set; }

    public string? Commune { get; set; }
}
