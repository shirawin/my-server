using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Users
{
    public interface IusersData
    {
        Task<int> checkPassword(string email, string password);
    }
}
