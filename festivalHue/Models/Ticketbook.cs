using System;
using System.Collections.Generic;

namespace festivalHue.Models;

public partial class Ticketbook
{
    public int Idbook { get; set; }

    public DateTime? Datecreatebook { get; set; }

    public DateTime? Datepay { get; set; }

    public string? Note { get; set; }

    public int? Money { get; set; }

    public int Idtransacstatus { get; set; }

    public string? Description { get; set; }

    public int? Idcustomer { get; set; }

    public virtual Deatailbookticket IdbookNavigation { get; set; } = null!;

    public virtual Customer? IdcustomerNavigation { get; set; }

    public virtual Transacstatus IdtransacstatusNavigation { get; set; } = null!;
}
