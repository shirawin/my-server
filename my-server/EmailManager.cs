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
            var subject = "ברוכים הבאים לנסיעה טובה 🖐🚗";
            var message = $@"<h2>הי {toName} ,</h2> 
                <h3>תודה שהצטרפת אלינו 🤗</h3>
                <h3>בקרוב תקבל מייל עם אישור מנהל</h3>
                <h3>שתיהיה לך נסיעה טובה 😁 </h3>";
            _emailService.Send(toEmail, subject, message, true);
        }
        public void SendOk(string toEmail, string toName)
        {
            var subject = "ברוכים הבאים לנסיעה טובה 🖐🚗";
            var message = $@"<h2>הי {toName} ,</h2> 
                <h3>נבחרת להיות חלק מקהילת נסיעת טובה</h3>
                <h3>מאחלים לך נסיעה טובה 😁 </h3>";
            _emailService.Send(toEmail, subject, message, true);
        }
        public void EmailWithDetails(User user,User volunteer)
        {
            var imagePath = @"C:\Users\user1\Desktop\Vs2022\BackendProject\server-side\my-server\my-server\Images\backImg.JPG";
            //var imagePath = @"C:\Users\user1\Desktop\Vs2022\backImg.JPG"ף\;
            var imageWidth = 300; // Specify the desired width in pixels
            var imageHeight = 200; // Specify the desired height in pixels
            var subject = "הידד 👏 , יש מתנדב והפרטים בפנים 👇";
            var message = $@"<div  style='direction:rtl'>
                <h2>הי {user.Fullname} ,</h2> 
                <h3>להלן פרטי המתנדב:</h3>
                <h4>שם-{volunteer.Fullname}</h4>
                <h4>טלפון-{volunteer.Phone}</h4>
                <h4>כתובת מייל -{volunteer.Email}</h4>
                <h2>שתהיה לך נסיעה טובה 😁 </h2> 
            </div>";
            _emailService.Send(user.Email, subject, message, true);
        }
    }
}
