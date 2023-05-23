using Microsoft.EntityFrameworkCore;
using Repositories.GeneratedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CarData
{
    public class CarsData: ICars
    {
        private readonly MyDBContext _context;
        public CarsData(MyDBContext context)
        {
            _context = context;
        }

        public async Task<bool> createCar(Car car)
        {
            var isOk = true;
            await _context.AddAsync(car);
            isOk = await _context.SaveChangesAsync() >= 0;
            if (isOk) return true;
            return false;
        }
        public async Task<bool> updateDetailsCar(Car car)
        {
            var carObj = await _context.Cars.FirstOrDefaultAsync(x => x.Userid == car.Userid);     
            if (carObj != null)
            {
                carObj.Privatecar = car.Privatecar;
                carObj.Motorcycle = car.Motorcycle;
                carObj.Ambulance = car.Ambulance;
                carObj.Numofsits = car.Numofsits;
                carObj.Stretcher = car.Stretcher;
                carObj.Elevator = car.Elevator;
                carObj.Babychair = car.Babychair;
            }
            var isOk = await _context.SaveChangesAsync() >= 0;

            return isOk;
            
        }
    }
}
