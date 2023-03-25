using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOS
{
    public class TravelDetailes
    {
        public bool? Motorcycle { get; set; }

        public bool? Car { get; set; }

        public bool? Ambulance { get; set; }

        public bool? BabyChair { get; set; }

        public bool? Elevator { get; set; }

        public int? Places { get; set; }

    }
}
