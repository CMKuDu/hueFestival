using System;
using System.Collections.Generic;

namespace festivalHue.Models;

public partial class Ticket
{
    public int Idticket { get; set; }

    public string? Nameticket { get; set; }

    public string? Description { get; set; }

    public decimal? Priceticket { get; set; }

    public string? Discount { get; set; }

    public DateTime? Datecreate { get; set; }

    public DateTime? Timeeffective { get; set; }

    public string? Bestseller { get; set; }

    public string? Active { get; set; }

    public string? Untistock { get; set; }

    public int Idtypeticket { get; set; }

    public virtual Tickettype IdtypeticketNavigation { get; set; } = null!;
}
