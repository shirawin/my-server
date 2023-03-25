using System;
using System.Collections.Generic;

namespace Repositories.GeneratedModels;

public partial class User
{
    public int Code { get; set; }

    public string? Fullname { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public bool? Activestatus { get; set; }

    public bool? Usertype { get; set; }

    public string? Password { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public int? Housenumber { get; set; }

    public virtual ICollection<Alarm> Alarms { get; } = new List<Alarm>();

    public virtual ICollection<Car> Cars { get; } = new List<Car>();

    public virtual ICollection<City> Cities { get; } = new List<City>();

    public virtual ICollection<Travel> Travels { get; } = new List<Travel>();

    public virtual ICollection<Volunteer> Volunteers { get; } = new List<Volunteer>();
}
