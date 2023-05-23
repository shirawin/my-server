using Repositories.GeneratedModels;
using Services.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services.Users
{
    public interface IusersData
    {
        Task<int> isExsitsUser(string email, string password);

        Task<bool> createUser(UserCar user);
       // Task<bool> updateUser(User user);
        Task<int> sumOfHelpeds();
        Task<User> getUser(int code);
        Task<bool> updateUser(User user);
    }
}
