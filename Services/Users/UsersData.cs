using Microsoft.EntityFrameworkCore;
using Repositories.GeneratedModels;
using Services.CarData;
using Services.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Email;
using Services.EmailData;
using Services.Alarms;

namespace Services.Users
{
    public class UsersData : IusersData
    {
        private readonly MyDBContext _context;
        private readonly ICars _carStore;
        private readonly IAlarmData _alarmStore;
        private readonly IEmailData _sendEmail;
        public UsersData(MyDBContext context, ICars carStore, IAlarmData alarmStore,IEmailData sendEmail)
        {
            _context = context;
            _carStore = carStore;
            _sendEmail = sendEmail;
           _alarmStore=alarmStore;
        }
        public async Task<int> isExsitsUser(string email, string password)
        {
            var checkEmail  = _context.Users.Where(u => u.Email == email).FirstOrDefault();
            if (checkEmail != null)
            {
                if (checkEmail.Password == password) { 
                
                    if (checkEmail.Activestatus == true) { 
                        return checkEmail.Code; //משתמש קיים!
}
                    else return -1;   // שם משתמש וסיסמה נכונים+משתמש לא פעיל
                }
                else return 1;    // סיסמה שגויה   
            }
            else return 2; //משתמש לא קיים
        }

        public async Task<bool> createUser(UserCar user)
        {
            var isExsists =await isExsitsUser(user.Email,user.Password);
            var isOk=true;
            var userCode = 0;
            User newUser = new User();
            newUser.Email = user.Email;
            newUser.Password = user.Password;
            newUser.Fullname = user.Fullname;
            newUser.Phone = user.Phone;
            newUser.Activestatus =false;
            newUser.Usertype= user.Usertype;
            newUser.City = user.City;
            newUser.Street=user.Street;
            newUser.Housenumber=user.Housenumber;
            if (isExsists == 2)
            {   await _context.AddAsync(newUser);
                isOk = await _context.SaveChangesAsync() >= 0;
                if (isOk) 
                    userCode = newUser.Code;
                else
                {
                    return false;
                }
            }
            if(user.Usertype==true)
            {
                Car newCar = new Car();
                newCar.Userid = userCode;

                newCar.Privatecar = user.Privatecar;

                newCar.Motorcycle = user.Motorcycle;

                newCar.Ambulance = user.Ambulance;

                newCar.Numofsits = user.Numofsits;

                newCar.Stretcher = user.Stretcher;

                newCar.Elevator = user.Elevator;

                newCar.Babychair = user.Babychair;

                var createCar=  await  _carStore.createCar(newCar);

                if (!createCar)
                    return false;
                else
                {
                    foreach (Alarm alarm in user.listOfAlarms)
                    {
                        alarm.Status = 1;
                        alarm.Userid = newUser.Code;
                        var createAlarm= await _alarmStore.createAlarm(alarm);
                        if (!createAlarm)
                        {
                            return false;
                        }

                    } 
                    _sendEmail.SendEmail(newUser.Email, newUser.Fullname);
                }
            }
            else 
            {
                _sendEmail.SendEmail(newUser.Email, newUser.Fullname);
                return true;
            }
            return false;
           
        }
        public async Task<int> sumOfHelpeds()
        {

            var helpeds = _context.Users.Where(u => u.Usertype == false).Count();
            return helpeds;
        }
        public void changeActiveStatus(int userID,bool activeStatus)
        {
            var user = _context.Users.Where(u => u.Code == userID).FirstOrDefault();
            user.Activestatus=activeStatus;
             _context.SaveChangesAsync();
        }
        public async Task<User> getUser(int code)
        {
            var user = _context.Users.Find(code);
            return user;
        }
        
        public async Task<bool> updateUser(User user)
        {
            var userId = await _context.Users.FirstOrDefaultAsync(x=>x.Code==user.Code);
            if (userId != null)
            {

          
            userId.Fullname=user.Fullname;
            //יש ליצור אוביקא מסוג DTO
            // כייון שמדובר בשילוב של משתמש ומתנדב.
            //  userId.Code=user.Code;
            //   userId.Usertype = user.Usertype;
            userId.Password = user.Password;
            userId.Email =user.Email;
            userId.Phone = user.Phone;
            userId.City = user.City;
            userId.Street = user.Street;
            userId.Housenumber = user.Housenumber;
            userId.Housenumber = user.Housenumber;
            userId.Housenumber = user.Housenumber;
            userId.Housenumber = user.Housenumber;
            userId.Housenumber = user.Housenumber;
            userId.Housenumber = user.Housenumber;

            }
            //להוסיף את שאר הנתונים.
            var isOk= await _context.SaveChangesAsync() >= 0;

           
            return isOk;
            
        }
    }
        
}

