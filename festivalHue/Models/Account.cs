using System;
using System.Collections.Generic;

namespace festivalHue.Models;

public partial class Account
{
    public int Idaccount { get; set; }

    public string? Nameaccount { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Salt { get; set; }

    public string? Active { get; set; }

    public DateTime? Datecreate { get; set; }

    public DateTime? Lastlogin { get; set; }

    public int Idrole { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual Role IdroleNavigation { get; set; } = null!;

    public virtual ICollection<News> News { get; set; } = new List<News>();
}
