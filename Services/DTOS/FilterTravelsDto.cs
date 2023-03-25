using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOS
{
    public class FilterTravelsDto
    {
        public DateTime? FirstDate { get; set; }
        public DateTime? SecondDate { get; set; }
        public string? city { get; set; }
    }
}
