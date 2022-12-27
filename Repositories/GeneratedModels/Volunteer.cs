using System;
using System.Collections.Generic;

namespace Repositories.GeneratedModels;

public partial class Volunteer
{
    public int? Usercode { get; set; }

    public int Voluntercode { get; set; }

    public string? City { get; set; }

    public virtual ICollection<Travel> Travels { get; } = new List<Travel>();

    public virtual User? UsercodeNavigation { get; set; }
}
