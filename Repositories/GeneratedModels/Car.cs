using System;
using System.Collections.Generic;

namespace Repositories.GeneratedModels;

public partial class Car
{
    public int Codecar { get; set; }

    public int? Userid { get; set; }

    public bool? Privatecar { get; set; }

    public bool? Motorcycle { get; set; }

    public bool? Ambulance { get; set; }

    public int? Numofsits { get; set; }

    public bool? Stretcher { get; set; }

    public bool? Elevator { get; set; }

    public bool? Babychair { get; set; }

    public virtual User? User { get; set; }
}
