using Repositories.GeneratedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Volunteers
{
    public class volunteerData:IvolunteerData
    {
        private readonly MyDBContext _context;
        public volunteerData(MyDBContext context)
        {
            _context = context;
        }

        public async Task<int> sumOfVolunteers()
        {
            var v = _context.Volunteers.Count();

            return v;
        }
    }
}
