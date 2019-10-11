using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using TravelExpenseChallenge.Manager;
using TravelExpenseChallenge.ViewModels;

namespace TravelExpenseChallenge.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeManager employeeManager;
        public EmployeeController(IEmployeeManager employeeManager)
        {
            this.employeeManager = employeeManager;
        }
        public IActionResult Login(EmployeeLoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = employeeManager.Find(viewModel);

                if (result.Designation == "Employee")
                    return RedirectToAction("Submit", "Home", new { email = result.Email });
                else
                    return RedirectToAction("Index", new RouteValueDictionary(new { controller = "Home", action = "Index", id = result.Id, role = result.Designation }));
            }
            return View();
        }
    }
}