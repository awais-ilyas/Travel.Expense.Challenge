using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelExpenseChallenge.Models;
using TravelExpenseChallenge.ViewModels;

namespace TravelExpenseChallenge.AutoMapper
{
    public class ModelMappingProfile : Profile
    {
        public ModelMappingProfile()
        {
            CreateMap<TravelExpense, TravelExpenseViewModel>();
            CreateMap<Employee, EmployeeViewModel>();
        }
    }
}
