using Microsoft.EntityFrameworkCore;
using Repositories.GeneratedModels;
using Services.DTOS;
using System.Security.Cryptography;

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
            var s_City = await _context.Users.FirstOrDefaultAsync(x => x.Code == travel.UserId);
            travel.Status = 1;
            await _context.Travels.AddAsync(travel);
            var isOK = await _context.SaveChangesAsync() >= 0;
            if (isOK)
            {

                var res = await (from c in _context.Cars
                                 join u in _context.Users
                                 on c.Userid equals u.Code

                                 where (travel.Motorcycle == true && c.Motorcycle==true) &&
                                 (travel.Ambulance == true && c.Ambulance == true) &&
                                 (travel.BabyChair == true && c.Babychair == true) &&
                                 (travel.Elevator == true && c.Elevator == true) &&
                                 (travel.Places == null || travel.Places >= c.Numofsits)&&
                                 (travel.Dest == u.City&& u.Usertype==true)&&
                                 (s_City.City == u.City && u.Usertype == true)
                                 select new 
                                  {
                                     Name = c.Ambulance,
                                     ClassName = u.Fullname 
                        }
    ).ToListAsync();
                return true;
            }
            return false;
        }

        public async Task<List<TravelDto>> filterTravel(FilterTravelsDto filterObj)
        {
            try
            {
                var res = await (from t in _context.Travels
                                 join u in _context.Users
                                 on t.UserId equals u.Code
                                 where
                                (filterObj.FirstDate == null || filterObj.FirstDate.Value.ToLocalTime() <= t.Time) &&
                (filterObj.SecondDate == null || filterObj.SecondDate.Value.ToLocalTime() >= t.Time)
                &&
                (filterObj.city == null || filterObj.city == u.City)
                &&
                (filterObj.cityDest == null || filterObj.cityDest == t.Dest)

                                 select new TravelDto
                                 {
                                     TravelId = t.TravelId,
                                     Date = t.Time,
                                     Dest = t.Dest,
                                     City = u.City,
                                     Street = u.Street,
                                     HouseNumber = u.Housenumber,
                                     List = _context.Travels.Where(x => x.TravelId == t.TravelId).Select(x => new TravelDetailes
                                     {
                                         Motorcycle = x.Motorcycle,
                                         Car = x.Car,
                                         Ambulance = x.Ambulance,

                                         BabyChair = x.BabyChair,

                                         Elevator = x.Elevator,

                                         Places = x.Places,
                                     }).FirstOrDefault(),
                                 }
                ).ToListAsync();
                return res;
            }
            catch (Exception e)
            {

            }
            return null;

            //var tes = await _context.Travels.Where(x=> (filterObj.FirstDate==null|| filterObj.FirstDate<=x.Date)&&
            //(filterObj.SecondDate == null || filterObj.SecondDate >= x.Date)
            //&& (filterObj.city == null || filterObj.city == x.c))
            //throw new NotImplementedException();
        }

        public async Task<List<TravelDto>> filterTravelsByUser(FilterTravelsDto filterObj, int userId)
        {
            try
            {
                var res = await (from t in _context.Travels
                                 join u in _context.Users
                                 on t.UserId equals u.Code
                                 where t.UserId == userId
                                 &&
                                (filterObj.FirstDate == null || filterObj.FirstDate.Value.ToLocalTime() <= t.Time) &&
                (filterObj.SecondDate == null || filterObj.SecondDate.Value.ToLocalTime() >= t.Time)
                &&
                (filterObj.city == null || filterObj.city == u.City)
                &&
                (filterObj.cityDest == null || filterObj.cityDest == t.Dest)

                                 select new TravelDto
                                 {
                                     TravelId = t.TravelId,
                                     Date = t.Time,
                                     Dest = t.Dest,
                                     City = u.City,
                                     Street = u.Street,
                                     HouseNumber = u.Housenumber,
                                     List = _context.Travels.Where(x => x.TravelId == t.TravelId).Select(x => new TravelDetailes
                                     {
                                         Motorcycle = x.Motorcycle,
                                         Car = x.Car,
                                         Ambulance = x.Ambulance,

                                         BabyChair = x.BabyChair,

                                         Elevator = x.Elevator,

                                         Places = x.Places,
                                     }).FirstOrDefault(),
                                 }
                ).ToListAsync();
                return res;
            }
            catch (Exception e)
            {

            }
            return null;

            //var tes = await _context.Travels.Where(x=> (filterObj.FirstDate==null|| filterObj.FirstDate<=x.Date)&&
            //(filterObj.SecondDate == null || filterObj.SecondDate >= x.Date)
            //&& (filterObj.city == null || filterObj.city == x.c))
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<TravelDto>> GetActiveTravels()
        {

            var res = await (from t in _context.Travels
                             join u in _context.Users
                             on t.UserId equals u.Code
                             where t.Status == 1
                             select new TravelDto
                             {
                                 TravelId = t.TravelId,
                                 Date = t.Time,
                                 Dest = t.Dest,
                                 City = u.City,
                                 Street = u.Street,
                                 HouseNumber = u.Housenumber,
                                 List = _context.Travels.Where(x => x.TravelId == t.TravelId).Select(x => new TravelDetailes
                                 {
                                     Motorcycle = x.Motorcycle,
                                     Car = x.Car,
                                     Ambulance = x.Ambulance,

                                     BabyChair = x.BabyChair,

                                     Elevator = x.Elevator,

                                     Places = x.Places,
                                 }).FirstOrDefault(),
                                 //Motorcycle = t.Motorcycle,
                                 //Car = t.Car,
                                 //Ambulance = t.Ambulance,

                                 //BabyChair = t.BabyChair,

                                 //Elevator = t.Elevator,

                                 //Places = t.Places,

                                 //Address = u.Address

                             }).ToListAsync();
            //List<Travel> list = _context.Travels.ToList();
            //var activeStatus = _context.Travels.Where(a => a.Status == 1).FirstOrDefault();
            return res;
        }

        public async Task<IEnumerable<TravelDto>> GetTravelsByUser(int userId)
        {

            var res = await (from t in _context.Travels
                             join u in _context.Users
                             on t.UserId equals u.Code
                             where t.Status == 1 && t.UserId == userId
                             select new TravelDto
                             {
                                 TravelId = t.TravelId,
                                 Date = t.Time,
                                 Dest = t.Dest,
                                 City = u.City,
                                 Street = u.Street,
                                 HouseNumber = u.Housenumber,
                                 List = _context.Travels.Where(x => x.TravelId == t.TravelId).Select(x => new TravelDetailes
                                 {
                                     Motorcycle = x.Motorcycle,
                                     Car = x.Car,
                                     Ambulance = x.Ambulance,

                                     BabyChair = x.BabyChair,

                                     Elevator = x.Elevator,

                                     Places = x.Places,
                                 }).FirstOrDefault(),
                                 //Motorcycle = t.Motorcycle,
                                 //Car = t.Car,
                                 //Ambulance = t.Ambulance,

                                 //BabyChair = t.BabyChair,

                                 //Elevator = t.Elevator,

                                 //Places = t.Places,

                                 //Address = u.Address

                             }).ToListAsync();
            //List<Travel> list = _context.Travels.ToList();
            //var activeStatus = _context.Travels.Where(a => a.Status == 1).FirstOrDefault();
            return res;
        }

        public async Task<int> sumOfTraves()
        {
            var travels = _context.Travels.Count();
            return travels;
        }
        public async Task<bool> takeTravel(int travelID, int volunteerID)
        {
            var travel = await _context.Travels.FirstOrDefaultAsync(t => t.TravelId == travelID);
            if (travel != null)
            {
                var isOk = true;
                travel.VolunteerId = volunteerID;
                travel.Status = 1;
                isOk = await _context.SaveChangesAsync() >= 0;
                if (isOk) return true;
                return false;
            }
            else
            {
                return false;
            }
        }
        public async Task<List<string>> getAllCities()
        {
            var uniqueDestinations = _context.Travels.Select(t => t.Dest).Distinct().ToList();
                return uniqueDestinations;
        }
        public async Task<bool> closeTravel(int travelID)
        {
            var travel = await _context.Travels.FirstOrDefaultAsync(t => t.TravelId == travelID);
            if (travel != null)
            {
                var isOk = true;
                travel.Status = 0;
                isOk = await _context.SaveChangesAsync() >= 0;
                if (isOk) return true;
                return false;
            }
            else
            {
                return false;
            }
        }

    }
}
