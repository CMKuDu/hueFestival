using System;
using System.Collections.Generic;

namespace festivalHue.Models;

public partial class Location
{
    public int Idlocation { get; set; }

    public string? Namelocation { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
