using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TravelExpenseChallenge.Models;

namespace TravelExpenseChallenge.ViewModels
{
    public class TravelExpenseViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int EmployeeId { get; set; }
        public ExpenseStatus Status { get; set; }
        public string PhotoPath { get; set; }
        public Employee Employee { get; set; }
        public DateTime SubmittedDate { get; set; }
    }
    public class TravelExpenseSubmitViewModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Title cannot exceed 50 characters")]
        public string Title { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public IFormFile Photo { get; set; }
        public string PhotoPath { get; set; }
    }
}
