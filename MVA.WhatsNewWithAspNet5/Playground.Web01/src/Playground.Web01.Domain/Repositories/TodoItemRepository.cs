using Playground.Web01.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;

namespace Playground.Web01.Domain.Repositories
{
    public interface ITodoItemRepository
    {
        TodoItem Get(Guid id);
        void Insert(TodoItem item);
        void Update(TodoItem item);
        List<TodoItem> GetAll();
        void Delete(Guid id);
    }

    public class TodoItemRepository : ITodoItemRepository
    {
        private static List<TodoItem> _source;

        private static List<TodoItem> _items
        {
            get
            {
                if (_source == null)
                    _source = new List<TodoItem>();

                return _source;
            }
        }

        public void Delete(Guid id)
        {
            var item =  _items.FirstOrDefault(i => i.Id == id);
            item.Delete();
        }

        public TodoItem Get (Guid id)
        {
            return _items.FirstOrDefault(i => i.Id == id && !i.DeletedDate.HasValue );
        }

        public List<TodoItem> GetAll()
        {
            return _items.Where(i=> !i.DeletedDate.HasValue).ToList();
        }

        public void Insert(TodoItem item)
        {
            _items.Add(item);
        }

        public void Update(TodoItem item)
        {
            var existing = _items.FirstOrDefault(i => i.Id == item.Id);
            existing.Update(item);
        }
    }
}
