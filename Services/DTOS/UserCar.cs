using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Repositories.GeneratedModels;

namespace Services.DTOS
{
    public class UserCar
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

        public int Codecar { get; set; }

        public int? Userid { get; set; }

        public bool? Privatecar { get; set; }

        public bool? Motorcycle { get; set; }

        public bool? Ambulance { get; set; }

        public int? Numofsits { get; set; }

        public bool? Stretcher { get; set; }

        public bool? Elevator { get; set; }

        public bool? Babychair { get; set; }
        public bool flag { get; set; }
        public List<Alarm>? listOfAlarms { get; set; }



    }
}
