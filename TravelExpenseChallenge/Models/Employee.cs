using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelExpenseChallenge.Models
{
    public class Employee : BaseEntity
    {
        [MaxLength(50, ErrorMessage = "First Name cannot exceed 50 characters")]
        public string FirstName { get; set; }
        [MaxLength(50, ErrorMessage = "Last Name cannot exceed 50 characters")]
        public string LastName { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        [StringLength(30)]
        public string Designation { get; set; }
        public int? SupervisorId { get; set; }
        public bool IsActive { get; set; }
    }
}
