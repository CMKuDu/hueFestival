using System;
using System.Collections.Generic;

namespace festivalHue.Models;

public partial class Role
{
    public int Idrole { get; set; }

    public string? Namerole { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
