using Playground.AngularJsTests.Web.Domain.Entities;
using System;

namespace Playground.AngularJsTests.Web.Models
{
    public class ExpenseViewModel
    {
        public string ExpenseId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Ammount { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }

        public ExpenseViewModel()
        { }

        internal ExpenseViewModel(ExpenseItem expense)
        {
            this.ExpenseId = expense.ExpenseId.ToString();
            this.Name = expense.Name;
            this.Description = expense.Description;
            this.Ammount = expense.Ammount;
            this.CreationDate = expense.CreationDate;
            this.ModificationDate = expense.ModificationDate;
        }

        internal ExpenseItem GenerateExpenseItem()
        {
            return new ExpenseItem(this.Name, this.Description, this.Ammount);
        }
    }
}