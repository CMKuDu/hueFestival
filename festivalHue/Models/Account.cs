using System;
using System.Collections.Generic;

namespace festivalHue.Models;

public partial class Account
{
    public int Idaccount { get; set; }

    public string? Nameaccount { get; set; }

    public int? Phone { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Salt { get; set; }

    public bool? Active { get; set; }

    public DateTime? Datecreate { get; set; }

    public DateTime? Lastlogin { get; set; }

    public int Idrole { get; set; }

    public virtual Role IdroleNavigation { get; set; } = null!;
}
