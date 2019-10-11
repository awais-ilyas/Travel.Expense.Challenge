using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelExpenseChallenge.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                 new Employee
                 {
                     Id = 1,
                     FirstName = "Awais",
                     LastName = "Ilyas",
                     Designation = "Employee",
                     Email = "awais.i@outlook.com",
                     IsActive = true,
                     PhoneNumber = "+971528565160",
                     SupervisorId = 3
                 },
                  new Employee
                  {
                      Id = 2,
                      FirstName = "Jonas",
                      LastName = "Klein",
                      Designation = "Employee",
                      Email = "jklein@domain.com",
                      IsActive = true,
                      PhoneNumber = "+12546987120",
                      SupervisorId = 4
                  },
                 new Employee
                 {
                     Id = 3,
                     FirstName = "John",
                     LastName = "Smith",
                     Designation = "TeamLeader",
                     Email = "jsmith@domain.com",
                     IsActive = true
                 },
                 new Employee
                 {
                     Id = 4,
                     FirstName = "John",
                     LastName = "Doe",
                     Designation = "TeamLeader",
                     Email = "jdoe@domain.com",
                     IsActive = true
                 },
                 new Employee
                 {
                     Id = 5,
                     FirstName = "Kevin",
                     LastName = "Arnold",
                     Designation = "FinanceManager",
                     Email = "karnold@domain.com",
                     IsActive = true
                 }
              );
        }
    }
}
