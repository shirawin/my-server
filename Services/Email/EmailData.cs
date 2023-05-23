﻿using NETCore.MailKit.Core;
using Repositories.GeneratedModels;
using Services.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.EmailData
{
    public class EmailData:IEmailData
    {
        private readonly IEmailService _emailService;

        public EmailData(IEmailService emailService)
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
        public void EmailWithDetails(User user, User volunteer)
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