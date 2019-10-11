using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using TravelExpenseChallenge.Manager;
using TravelExpenseChallenge.Models;
using TravelExpenseChallenge.ViewModels;

namespace TravelExpenseChallenge.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ITravelExpenseManager expenseManager;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly ILogger logger;

        public HomeController(ITravelExpenseManager expenseManager, 
            IHostingEnvironment hostingEnvironment,
            ILogger<HomeController> logger)
        {
            this.expenseManager = expenseManager;
            this.hostingEnvironment = hostingEnvironment;
            this.logger = logger;
        }
        [AllowAnonymous]
        public IActionResult Index(int id)
        {
            //logger.LogTrace("Trace Log");

            IEnumerable<TravelExpenseViewModel> travelExpenses = null;
            travelExpenses = expenseManager.Get(id);
            if (travelExpenses == null)
                travelExpenses = expenseManager.GetAll();
            return View(travelExpenses);
        }
        [AllowAnonymous]
        public ViewResult Details(int id)
        {
            //throw new Exception("Error in Details View");

            var result = expenseManager.GetById(id);
            TravelExpenseViewModel model = new TravelExpenseViewModel()
            {
                EmployeeId = result.EmployeeId,
                PhotoPath = result.PhotoPath,
                Status = result.Status,
                Title = result.Title
            };

            return View(model);
        }

        [HttpGet]
        public ViewResult Submit()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Submit(TravelExpenseSubmitViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Photo != null)
                {
                    string uploadPhoto = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadPhoto, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                model.PhotoPath = uniqueFileName;

                int Id = expenseManager.Add(model);
                if (Id > 0)
                    return RedirectToAction("details", new { id = Id });
            }
            return View();
        }
        
        [HttpPost]
        public IActionResult Approve(int Id)
        {
            if (Id > 0)
            {
                bool response = expenseManager.Approve(Id);
                if (response)
                    return RedirectToAction("details", new { id = Id });
            }
            return View();
        }
        
        [HttpPost]
        public IActionResult Reject(int Id)
        {
            if (Id > 0)
            {
                bool response = expenseManager.Reject(Id);
                if (response)
                    return RedirectToAction("details", new { id = Id });
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        public IActionResult ExportToExcel()
        {
            string WebRootFolder = hostingEnvironment.WebRootPath;
            string FileName = @"TravelExpense.xlsx";
            string URL = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, FileName);
            FileInfo file = new FileInfo(Path.Combine(WebRootFolder, FileName));
            var memory = new MemoryStream();
            using (var fs = new FileStream(Path.Combine(WebRootFolder, FileName), FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook;
                workbook = new XSSFWorkbook();
                ISheet excelSheet = workbook.CreateSheet("TravelExpense.xlsx");
                IRow row = excelSheet.CreateRow(0);

                row.CreateCell(0).SetCellValue("Title");
                row.CreateCell(1).SetCellValue("Submit By");
                row.CreateCell(2).SetCellValue("Status");
                row.CreateCell(3).SetCellValue("Date");

                var expenses = expenseManager.GetAll();
                int count = 0;
                foreach (var item in expenses)
                {
                    count += 1;
                    row = excelSheet.CreateRow(count);
                    row.CreateCell(0).SetCellValue(item.Title);
                    row.CreateCell(1).SetCellValue($"{item.Employee.FirstName} {item.Employee.LastName}");
                    row.CreateCell(2).SetCellValue(item.Status.ToString());
                    row.CreateCell(3).SetCellValue(item.SubmittedDate.ToString("MM/dd/yyyy hh:mm tt"));
                }
                workbook.Write(fs);
            }
            using (var stream = new FileStream(Path.Combine(WebRootFolder, FileName), FileMode.Open))
            {
                stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", FileName);
        }
    }
}
