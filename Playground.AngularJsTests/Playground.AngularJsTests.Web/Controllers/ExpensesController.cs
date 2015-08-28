using System;
using System.Collections.Generic;
using System.Web.Http;
using Playground.AngularJsTests.Web.Domain.Repositories;
using Playground.AngularJsTests.Web.Models;

namespace Playground.AngularJsTests.Web.Controllers
{
    public class ExpensesController : ApiController
    {
        private ExpenseItemRepository _repository;

        public ExpensesController()
        {
            this._repository = new ExpenseItemRepository();
        }

        // GET: api/Expenses
        public IEnumerable<ExpenseViewModel> Get()
        {
            List<ExpenseViewModel> model = new List<ExpenseViewModel>();
            this._repository.GetAll().ForEach(i => model.Add(new ExpenseViewModel(i)));
            return model;
        }

        // GET: api/Expenses/5
        public ExpenseViewModel Get(string id)
        {
            Guid expenseId;
            if (!Guid.TryParse(id, out expenseId))
                return null;

            var item = this._repository.Get(expenseId);
            if (item == null)
                return null;

            return new ExpenseViewModel(item);
        }

        // POST: api/Expenses
        public void Post(ExpenseViewModel expenseItem)
        {
            this._repository.Create(expenseItem.GenerateExpenseItem());
        }

        // PUT: api/Expenses
        public void Put(ExpenseViewModel expenseItem)
        {
            this._repository.Update(new Guid(expenseItem.ExpenseId), expenseItem.Name, expenseItem.Description, expenseItem.Ammount);
        }

        // DELETE: api/Expenses/a guid
        public void Delete(string id)
        {
            Guid expenseId;
            if (!Guid.TryParse(id, out expenseId))
                return;

            this._repository.Delete(expenseId);
        }
    }
}
