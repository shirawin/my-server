using Repositories.GeneratedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Users
{
    public class UsersData : IusersData
    {
        private readonly MyDBContext _context;
        public UsersData(MyDBContext context)
        {
            _context = context;
        }
        public async Task<int> checkPassword(string email, string password)
        {
           
            List<User> list = _context.Users.ToList();
            var checkEmail  = _context.Users.Where(u => u.Email == email).FirstOrDefault();
            if (checkEmail != null)
            {
                var checkPassWord = _context.Users.Where(u => u.Password == password).FirstOrDefault();
                if (checkPassWord != null)
                {

                    if (checkPassWord.Activestatus == true)
                        return checkPassWord.Code;
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return 1;
                }
                    
            }
            else
            {
               return 2;
            }
            //foreach (var user in list)
            //{
            //    if (user.Email == email)
            //        if (user.Password == password)
            //            if (user.Activestatus == true)
            //            {
            //                return user.Code; // שם משתמש וסיסמה נכונים+ משתמש פעיל
            //            }
            //            else
            //            {
            //                if (user.Activestatus == false)
            //                {
            //                    return -1; // שם משתמש וסיסמה נכונים+ משתמש לא פעיל
            //                }
            //                return 0; // שם משתמש וסיסמה נכונים+ משתמש חסום
            //            }
            //        else
            //            return 1; //משתמש קיים - סיסמה שגויה
            //}
            //return 2; //משתמש לא קיים
        }
    }
}
