using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOS
{
    public class TravelDto
    {
        public int TravelId { get; set; }
        public DateTime? Date { get; set; }

        public string? Dest { get; set; }



        public string? City { get; set; }
        public string? Street { get; set; }

        public int? HouseNumber { get; set; }

        public TravelDetailes List { get; set; }

            

    }
}
