using System;
using System.Collections.Generic;

namespace festivalHue.Models;

public partial class Tickettype
{
    public int Idtypeticket { get; set; }

    public string? Nametypeticket { get; set; }

    public string? Descriptionticket { get; set; }

    public string? Puslish { get; set; }

    public string? Aliasticket { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
