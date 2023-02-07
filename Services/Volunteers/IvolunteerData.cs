using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Volunteers
{
    public interface IvolunteerData
    {
        Task<int> sumOfVolunteers();

    }
}
