using System;
using System.Collections.Generic;

namespace festivalHue.Models;

public partial class News
{
    public int Idnews { get; set; }

    public string? Title { get; set; }

    public string? Alias { get; set; }

    public string? Author { get; set; }

    public DateTime? Datecreate { get; set; }

    public string? Description { get; set; }

    public string? Content { get; set; }
}
