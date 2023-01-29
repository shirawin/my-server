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
        public async Task<int> isExsitsUser(string email, string password)
        {
            var checkEmail  = _context.Users.Where(u => u.Email == email).FirstOrDefault();
            if (checkEmail != null)
            {
                var checkPassWord = _context.Users.Where(u => u.Password == password).FirstOrDefault();
                if (checkPassWord != null)
                {
                    if (checkPassWord.Activestatus == true)
                        return checkPassWord.Code; //משתמש קיים!

                    else return -1;   // שם משתמש וסיסמה נכונים+משתמש לא פעיל
                }
                else return 1;    // סיסמה שגויה   
            }
            else return 2; //משתמש לא קיים
        }

        public async Task<bool> createUser(User user)
        {
            var isExsists =await isExsitsUser(user.Email,user.Password);
            var isOk=true;
            int x = 2;
            if (isExsists == 2)
            {
                //var userModel = _mapper.Map<User>(user);
                await _context.AddAsync(user);
                isOk = await _context.SaveChangesAsync() >= 0;
                if (isOk) return true;    
            }
            return false;
        }

    }
}
