using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Playground.Web01.Domain.Repositories;
using Playground.Web01.Domain.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Playground.Web01.Controllers
{
    [Route("api/[controller]")]
    public class ToDoItemsController : Controller
    {
        [FromServices]
        public ITodoItemRepository _itemRepository { get; set; }

        // GET: api/values
        [HttpGet]
        public IEnumerable<TodoItem> Get()
        {
            return _itemRepository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id:Guid}")]
        public TodoItem Get(Guid id)
        {
            if (id == new Guid())
                throw new ArgumentNullException("Id can't be null");

            return _itemRepository.Get(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]TodoItem item)
        {
            if (item == null)
                throw new ArgumentNullException("Item can't be null");
            _itemRepository.Insert(item);
        }

        // PUT api/values/5
        [HttpPut]
        public void Put([FromBody]TodoItem item)
        {
            if (item == null)
                throw new ArgumentNullException("Item can't be null");

            _itemRepository.Update(item);
        }

        // DELETE api/values/5
        [HttpDelete("{id:Guid}")]
        public void Delete(Guid id)
        {
            if (id == new Guid())
                throw new ArgumentNullException("Id can't be null");

            _itemRepository.Delete(id);
        }
    }
}
