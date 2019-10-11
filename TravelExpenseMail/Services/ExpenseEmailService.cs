using System;
using System.Collections.Generic;
using System.Text;
using TravelExpenseMail.Helpers;
using TravelExpenseMail.Models;

namespace TravelExpenseMail.Services
{
    public interface IExpenseEmailService
    {
        void SendExpenseEmail(ExpenseEmail model);
    }
    public class ExpenseEmailService : BaseService, IExpenseEmailService
    {
        public ExpenseEmailService(Microsoft.Extensions.Options.IOptions<MailSetting> settings)
            : base(settings)
        {

        }
        public void SendExpenseEmail(ExpenseEmail model)
        {
            string template = "Templates.ExpenseSubmit";
            RazorParser renderer = new RazorParser(typeof(IExpenseEmailService).Assembly);
            var body = renderer.UsingTemplateFromEmbedded(template, model);
            SendEmail(new List<string>() { model.ToEmail }, model.Subject, body, typeof(IExpenseEmailService));
        }
    }
}
