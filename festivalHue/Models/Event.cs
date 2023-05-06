using System;
using System.Collections.Generic;

namespace festivalHue.Models;

public partial class Event
{
    public int Idevent { get; set; }

    public string? Nameevent { get; set; }

    public string? Alias { get; set; }

    public bool? Puslish { get; set; }

    public string? Thumb { get; set; }

    public DateTime? Datecreate { get; set; }
}
