using Microsoft.EntityFrameworkCore;
using Repositories.GeneratedModels;
using Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Travels
{
    public class TravlesData : ItravelsData
    {
        private readonly MyDBContext _context;
        public TravlesData(MyDBContext context)
        {
            _context = context;
        }

        public async Task<bool> createTravel(Travel travel)
        {
            await _context.Travels.AddAsync(travel);
            var isOK = await _context.SaveChangesAsync() >= 0;
            if(isOK)
            {
                return true;
            }
            return false;
        }

        public Task<IEnumerable<Travel>> GetActiveTravels()
        {

            //List<Travel> list = _context.Travels.ToList();
            //var activeStatus = _context.Travels.Where(a => a.Status == 1).FirstOrDefault();
            return (Task<IEnumerable<Travel>>)_context.Travels.Where(a => a.Status == 1);
        }
       public async Task<int> sumOfTraves()
        {
            var travels = _context.Travels.Count();
            return travels;
        }


    }
}
