using System;
using System.Collections.Generic;

namespace Repositories.GeneratedModels;

public partial class Alarm
{
    public int Codealarm { get; set; }

    public int? Userid { get; set; }

    public int? Status { get; set; }

    public string? Minhour { get; set; }

    public string? Maxhour { get; set; }

    public virtual User? User { get; set; }
}
