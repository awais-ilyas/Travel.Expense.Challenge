using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelExpenseChallenge.Models;
using TravelExpenseChallenge.Repository;
using TravelExpenseChallenge.ViewModels;

namespace TravelExpenseChallenge.Manager
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly AppDbContext context;
        private IRepository<Employee> employeeManager;
        private IMapper _mapper;
        public EmployeeManager(AppDbContext context,
            IRepository<Employee> employeeManager,
               IMapper mapper)
        {
            this.context = context;
            this.employeeManager = employeeManager;
            _mapper = mapper;
        }

        public EmployeeViewModel Find(EmployeeLoginViewModel employee)
        {
             return _mapper.Map<EmployeeViewModel>(employeeManager.Find(x => x.Email == employee.Email));
        }
    }
}
