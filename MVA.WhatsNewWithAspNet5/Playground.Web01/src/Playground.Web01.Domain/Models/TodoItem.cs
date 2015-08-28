using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playground.Web01.Domain.Models
{
    public class TodoItem
    {
        public Guid Id { get; set;}

        public string Description { get; private set;}

        public bool Done { get; private set; }

        public DateTime CreationDate { get; private set; }

        public DateTime UpdateDate { get; private set; }

        public DateTime? DeletedDate { get; private set; }

        public TodoItem(string description, bool done)
        {
            Id = Guid.NewGuid();
            Description = description;
            Done = done;
            CreationDate = DateTime.Now;
            UpdateDate = CreationDate;
        }

        public static TodoItem Generate(string description, bool done)
        {
            return new TodoItem(description, done);
        }

        internal void Update(TodoItem item)
        {
            Description = item.Description;
            Done = item.Done;
            UpdateDate = DateTime.Now;
        }

        internal void Delete()
        {
            this.DeletedDate = DateTime.Now;
        }
    }
}
