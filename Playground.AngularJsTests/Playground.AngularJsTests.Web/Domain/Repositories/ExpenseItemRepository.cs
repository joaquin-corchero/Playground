using Playground.AngularJsTests.Web.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Playground.AngularJsTests.Web.Domain.Repositories
{
    public class ExpenseItemRepository
    {
        private static List<ExpenseItem> _expenses;

        protected static List<ExpenseItem> ExpenseTable
        {
            get
            {
                if (_expenses == null)
                    _expenses = new List<ExpenseItem>();

                return _expenses;
            }
        }

        public void Create(ExpenseItem expense)
        {
            ExpenseTable.Add(expense);
        }

        internal void Update(Guid expenseId, string name, string description, decimal ammount)
        {
            var existing = ExpenseTable.FirstOrDefault(e => e.ExpenseId == expenseId);
            existing.SetName(name);
            existing.SetDescription(description);
            existing.SetAmmount(ammount);
            existing.SetModificationDate();
        }

        public List<ExpenseItem> GetAll()
        {
            return ExpenseTable;
        }

        public ExpenseItem Get(Guid expenseId)
        {
            return ExpenseTable.FirstOrDefault(e => e.ExpenseId == expenseId);
        }

        internal void Delete(Guid expenseId)
        {
            ExpenseTable.RemoveAll(r => r.ExpenseId == expenseId);
        }
    }
}