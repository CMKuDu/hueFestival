using System;
using System.Collections.Generic;

namespace festivalHue.Models;

public partial class Transacstatus
{
    public int Idtransacstatus { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Ticketbook> Ticketbooks { get; set; } = new List<Ticketbook>();
}
