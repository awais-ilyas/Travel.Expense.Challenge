using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelExpenseChallenge.Models;
using TravelExpenseChallenge.ViewModels;

namespace TravelExpenseChallenge.Manager
{
    public interface ITravelExpenseManager
    {
        IEnumerable<TravelExpenseViewModel> Get(int Id);
        IEnumerable<TravelExpenseViewModel> GetAll();
        TravelExpense GetById(int Id);
        int Add(TravelExpenseSubmitViewModel expense);
        bool Approve(int Id);
        bool Reject(int Id);
    }
}
