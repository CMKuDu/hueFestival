using System;
using System.Collections.Generic;

namespace festivalHue.Models;

public partial class Deatailbookticket
{
    public int Idbook { get; set; }

    public int Idstatus { get; set; }

    public int Idcustomer { get; set; }

    public virtual Customer IdcustomerNavigation { get; set; } = null!;

    public virtual ICollection<Ticketbook> Ticketbooks { get; set; } = new List<Ticketbook>();
}
