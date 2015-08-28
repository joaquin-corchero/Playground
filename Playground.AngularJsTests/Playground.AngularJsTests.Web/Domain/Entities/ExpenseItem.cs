using System;
using System.Diagnostics.Contracts;

namespace Playground.AngularJsTests.Web.Domain.Entities
{
    public class ExpenseItem
    {
        public Guid ExpenseId { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public decimal Ammount { get; private set; }

        public DateTime CreationDate { get; private set; }

        public DateTime ModificationDate { get; private set; }

        public ExpenseItem(string name, string description, decimal ammount)
        {
            this.ExpenseId = Guid.NewGuid();
            this.SetName(name);
            this.SetDescription(description);
            this.SetAmmount(ammount);
            this.CreationDate = DateTime.Now;
            this.SetModificationDate();
        }

        internal void SetModificationDate()
        {
            this.ModificationDate = DateTime.Now;
        }

        public static ExpenseItem Generate(string name, string description, decimal ammount)
        {
            var result = new ExpenseItem(name, description, ammount);
            Contract.Ensures(result != null);
            return result;
        }

        internal void SetName(string name)
        {
            Contract.Requires(!string.IsNullOrEmpty(name));
            this.Name = name;
        }

        internal void SetDescription(string description)
        {
            Contract.Requires(!string.IsNullOrEmpty(description));
            this.Description = description;
        }

        internal void SetAmmount(decimal ammount)
        {
            Contract.Requires(ammount > 0);
            Contract.Requires(ammount < decimal.MaxValue);

            this.Ammount = ammount;
        }
    }
}