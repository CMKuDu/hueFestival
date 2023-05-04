using System;
using System.Collections.Generic;

namespace festivalHue.Models;

public partial class Customer
{
    public int Idcustomer { get; set; }

    public string? Namecustomer { get; set; }

    public DateTime? Birthdaycustomer { get; set; }

    public byte[]? Avatar { get; set; }

    public string? Addresscustomer { get; set; }

    public string? Emailcustomer { get; set; }

    public string? Phonecustomer { get; set; }

    public int Idlocation { get; set; }

    public virtual Location IdlocationNavigation { get; set; } = null!;

    public virtual ICollection<Ticketbook> Ids { get; set; } = new List<Ticketbook>();
}
