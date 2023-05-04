using System;
using System.Collections.Generic;

namespace festivalHue.Models;

public partial class Ticketbook
{
    public int Idbook { get; set; }

    public DateTime? Datecreatebook { get; set; }

    public DateTime? Datepay { get; set; }

    public string? Note { get; set; }

    public decimal? Money { get; set; }

    public int Idtransacstatus { get; set; }

    public string? Description { get; set; }

    public virtual Transacstatus IdtransacstatusNavigation { get; set; } = null!;

    public virtual ICollection<Customer> Ids { get; set; } = new List<Customer>();
}
