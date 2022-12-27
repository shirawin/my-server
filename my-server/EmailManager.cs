using NETCore.MailKit.Core;

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
                <p>להתראות!</p>";
            _emailService.Send(toEmail, subject, message, true);
        }
    }
}
