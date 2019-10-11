using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelExpenseChallenge.Models;
using TravelExpenseChallenge.Repository;
using TravelExpenseChallenge.ViewModels;
using TravelExpenseMail.Models;
using TravelExpenseMail.Services;

namespace TravelExpenseChallenge.Manager
{
    public class TravelExpenseManager : ITravelExpenseManager
    {
        private readonly AppDbContext context;
        private IRepository<TravelExpense> expenseManager;
        private IRepository<Employee> employeeManager;
        private readonly IExpenseEmailService expenseEmailService;
        private IMapper mapper;
        private readonly ILogger<TravelExpenseManager> logger;

        public TravelExpenseManager(AppDbContext context,
            IRepository<TravelExpense> expenseManager,
            IRepository<Employee> employeeManager,
            IExpenseEmailService expenseEmailService,
            IMapper mapper, 
            ILogger<TravelExpenseManager> logger)
        {
            this.context = context;
            this.expenseManager = expenseManager;
            this.employeeManager = employeeManager;
            this.expenseEmailService = expenseEmailService;
            this.mapper = mapper;
            this.logger = logger;
        }

        #region EXPENSE FUNCTIONS
        public int Add(TravelExpenseSubmitViewModel viewModel)
        {
            var user = employeeManager.Find(u => u.Email == viewModel.Email);
            if (user != null)
            {
                TravelExpense model = new TravelExpense
                {
                    Title = viewModel.Title,
                    PhotoPath = viewModel.PhotoPath,
                    Status = ExpenseStatus.Pending,
                    EmployeeId = user.Id
                };
                var expense = expenseManager.Insert(model);
                if (expense.Id > 0)
                    // Send an expense email to Finance Manager
                    SendExpenseEmail(expense.Id);
                return expense.Id;
            }
            else
                return 0;
        }

        public IEnumerable<TravelExpenseViewModel> Get(int Id)
        {
            var user = employeeManager.Get(Id);
            if (user != null)
            {
                var employeExpenses = expenseManager.GetAll(x => x.Employee)
                    .Where(a => user.Designation == "TeamLeader" ? a.Employee.SupervisorId == user.Id :
                    (user.Designation == "Employee" ? a.EmployeeId == user.Id : true));

                return mapper.Map<IEnumerable<TravelExpenseViewModel>>(employeExpenses);
            }
            return null;
        }
        public IEnumerable<TravelExpenseViewModel> GetAll()
        {
            logger.LogTrace("Trace Log");
            var expenses = mapper.Map<IEnumerable<TravelExpenseViewModel>>(expenseManager.GetAll(x => x.Employee).OrderByDescending(o => o.SubmittedDate));
            return expenses;
        }
        public TravelExpense GetById(int Id)
        {
            var record = expenseManager.Get(Id);
            return record;
        }
        public bool Approve(int Id)
        {
            var expense = expenseManager.Get(Id);
            if (expense != null)
            {
                expense.Status = ExpenseStatus.Approved;
                expense.ApprovedDate = DateTime.UtcNow;

                expenseManager.Update(expense);
                return true;
            }
            else
                return false;
        }
        public bool Reject(int Id)
        {
            var expense = expenseManager.Get(Id);
            if (expense != null)
            {
                expense.Status = ExpenseStatus.Rejected;
                expense.ApprovedDate = DateTime.UtcNow;

                expenseManager.Update(expense);

                return true;
            }
            else
                return false;
        }
        #endregion

        #region EXPENSE EMAIL
        public bool SendExpenseEmail(int id)
        {
            var expense = expenseManager.Get(id);
            if (expense != null)
            {
                try
                {
                    var user = employeeManager.Find(a => a.Designation == "FinanceManager");

                    ExpenseEmail expenseEmail = new ExpenseEmail();
                    expenseEmail.ToEmail = user.Email;
                    expenseEmail.Subject = "Trivago Travel Expense Submitted";
                    expenseEmail.Body = $"An expense has been submitted with title: '{expense.Title}'";

                    expenseEmailService.SendExpenseEmail(expenseEmail);

                    return true;
                }
                catch (Exception ex)
                {
                    return true;
                }
            }
            else
                return false;
        }
        #endregion
    }
}
