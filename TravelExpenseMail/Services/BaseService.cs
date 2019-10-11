using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using TravelExpenseMail.Models;

namespace TravelExpenseMail.Services
{
    public interface IBaseService
    {
        void SendEmail(IEnumerable<string> toAddresses, string subject, string body, Type type, IEnumerable<Attachment> attachments = null);
    }
    public class BaseService : IBaseService
    {
        private readonly Microsoft.Extensions.Options.IOptions<MailSetting> settings;
        private SmtpClient client;
        private readonly string SendEmailFrom;
        public BaseService(Microsoft.Extensions.Options.IOptions<MailSetting> settings)
        {
            this.settings = settings;
            client = new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true,
                Host = settings.Value.Host,
                Port = Convert.ToInt32(this.settings.Value.Port)
            };

            //Setup SMTP Authentication
            SendEmailFrom = this.settings.Value.From;
            string SupportEmail = this.settings.Value.Email;
            string SupportEmailPassword = this.settings.Value.Password;

            NetworkCredential credentials = new NetworkCredential(SupportEmail, SupportEmailPassword);
            client.UseDefaultCredentials = false;
            client.Credentials = credentials;
            client.SendCompleted += Client_SendCompleted;
        }
        public void SendEmail(IEnumerable<string> toAddresses, string subject, string body, Type type, IEnumerable<Attachment> attachments = null)
        {
            MailMessage msg = new MailMessage
            {
                From = new MailAddress(SendEmailFrom),
                Subject = subject,
                IsBodyHtml = true,
                Body = body
            };

            foreach (var toAddress in toAddresses)
            {
                msg.To.Add(new MailAddress(toAddress));
            }

            if (attachments != null)
            {
                foreach (var attachment in attachments)
                {
                    msg.Attachments.Add(attachment);
                }
            }
            client.SendAsync(msg, type.Assembly.FullName);
        }
        private void Client_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            var state = e.UserState.ToString();
        }
    }
}
