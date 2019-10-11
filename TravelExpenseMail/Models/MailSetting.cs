using System;
using System.Collections.Generic;
using System.Text;

namespace TravelExpenseMail.Models
{
    public class MailSetting
    {
        public string From { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        //for network credentials
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
