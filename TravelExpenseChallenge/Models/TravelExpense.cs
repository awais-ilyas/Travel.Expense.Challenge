using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelExpenseChallenge.Models
{
    public class TravelExpense : BaseEntity
    {
        public TravelExpense()
        {
            SubmittedDate = DateTime.UtcNow;
        }

        [StringLength(50)]
        public string Title { get; set; }
        public ExpenseStatus Status { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime SubmittedDate { get; set; }
        public int? ApprovedById { get; set; }
        public Employee ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string PhotoPath { get; set; }
    }
    public enum ExpenseStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2
    }
}
