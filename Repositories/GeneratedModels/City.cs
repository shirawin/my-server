using System;
using System.Collections.Generic;

namespace Repositories.GeneratedModels;

public partial class City
{
    public int Codecity { get; set; }

    public int? Userid { get; set; }

    public string? Cityname { get; set; }

    public virtual User? User { get; set; }
}
