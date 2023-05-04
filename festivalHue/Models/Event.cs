using System;
using System.Collections.Generic;

namespace festivalHue.Models;

public partial class Event
{
    public int Idevent { get; set; }

    public string? Nameevent { get; set; }

    public string? Alias { get; set; }

    public string? Puslish { get; set; }

    public byte[]? Thumb { get; set; }

    public DateTime? Datecreate { get; set; }

    public int Idaccount { get; set; }

    public int Idrole { get; set; }

    public virtual Account Id { get; set; } = null!;
}
