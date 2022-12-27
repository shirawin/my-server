using System;
using System.Collections.Generic;

namespace Repositories.GeneratedModels;

public partial class Travel
{
    public int TravelId { get; set; }

    public int? UserId { get; set; }

    public int? VolunteerId { get; set; }

    public int? Status { get; set; }

    public DateOnly? Date { get; set; }

    public DateTime? Time { get; set; }

    public string? Dest { get; set; }

    public bool? Motorcycle { get; set; }

    public bool? Car { get; set; }

    public bool? Ambulance { get; set; }

    public bool? BabyChair { get; set; }

    public bool? Elevator { get; set; }

    public int? Places { get; set; }

    public virtual User? User { get; set; }

    public virtual Volunteer? Volunteer { get; set; }
}
