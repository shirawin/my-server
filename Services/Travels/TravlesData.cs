using Microsoft.EntityFrameworkCore;
using Repositories.GeneratedModels;
using Services.DTOS;
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
            travel.UserId = 125;
            travel.Status = 1;
            await _context.Travels.AddAsync(travel);
            var isOK = await _context.SaveChangesAsync() >= 0;
            if (isOK)
            {
                return true;
            }
            return false;
        }

        public async Task<List<TravelDto>> filterTravel(FilterTravelsDto filterObj)
        {
            var res = await (from t in _context.Travels
                             join u in _context.Users           
                             on t.UserId equals u.Code
                             where 
            //                 (filterObj.FirstDate == null || filterObj.FirstDate <= t.Time) &&
            //(filterObj.SecondDate == null || filterObj.SecondDate >= t.Time)
            //&& 
            (filterObj.city == null || filterObj.city == u.City)

                             select new TravelDto
                             {
                                 TravelId = t.TravelId,
                                 Date = t.Date,
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
                                 Date = t.Date,
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
        public async Task<int> takeTravel(int travelID, int volunteerID)
        {
            var travel = await _context.Travels.FirstOrDefaultAsync(t => t.TravelId == travelID);
            if (travel != null)
            {
                travel.VolunteerId = volunteerID;
                travel.Status = 1;
                return await _context.SaveChangesAsync();
            }
            else
            {
                return 0;
            }
        }


    }
}
