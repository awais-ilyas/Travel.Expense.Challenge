using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelExpenseChallenge.Models;
using TravelExpenseChallenge.ViewModels;

namespace TravelExpenseChallenge.Manager
{
    public interface IEmployeeManager
    {
        EmployeeViewModel Find(EmployeeLoginViewModel model);
    }
}
