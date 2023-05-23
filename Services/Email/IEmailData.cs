using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Email
{
    public interface IEmailData
    {
        void SendEmail(string toEmail, string toName);
    }
}
