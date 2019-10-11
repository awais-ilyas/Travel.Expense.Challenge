using System;
using System.Collections.Generic;
using System.Text;

namespace TravelExpenseMail.Models
{
    public class ExpenseEmail
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
