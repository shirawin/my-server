using NETCore.MailKit.Core;
using Repositories.GeneratedModels;

namespace my_server
{
    public class EmailManager
    {
        private readonly IEmailService _emailService;

        public EmailManager(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public void SendEmail(string toEmail, string toName)
        {
            var subject = "ברוכים הבאים לאפליקציה המגניבה 🖐";
            var message = $@"<h3>הי, {toName}</h3> 
                <p>תודה שהצטרפת אלינו 🤗</p>
                <p>ברוך הבא</p>";
            _emailService.Send(toEmail, subject, message, true);
        }
        public void EmailWithDetails(User user,User volunteer)
        {
            var subject = "הידד,נמצא מתנדב ולהלן הפרטים:";
            var message = $@"<h3>הי,{user.Fullname} </h3> 
                <p>להלן פרטי המתנדב:</p>
                <p>שם-{volunteer.Fullname}</p>
                <p>טלפון-{volunteer.Phone}</p>
                <p>כתובת מייל -{volunteer.Email}</p>";
            _emailService.Send(user.Email, subject, message, true);
        }
    }
}
