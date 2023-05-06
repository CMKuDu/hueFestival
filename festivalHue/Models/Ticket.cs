using System;
using System.Collections.Generic;

namespace festivalHue.Models;

public partial class Ticket
{
    public int Idticket { get; set; }

    public string? Nameticket { get; set; }

    public string? Description { get; set; }

    public int? Priceticket { get; set; }

    public DateTime? Datecreate { get; set; }

    public DateTime? Timeeffective { get; set; }

    public bool? Bestseller { get; set; }

    public bool? Active { get; set; }

    public bool? Untistock { get; set; }

    public int Idtypeticket { get; set; }

    public int? Disscount { get; set; }

    public virtual Tickettype IdtypeticketNavigation { get; set; } = null!;
}
