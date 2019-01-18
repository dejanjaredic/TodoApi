using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Produces("application/json")]
    [Route("api/todo")]
    [ApiController]
    public class TodoController : Controller
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;
            if (_context.TodoItems.Count() ==0)
            {
                _context.TodoItems.Add(new TodoItem { Name = "Item 1"});
                _context.SaveChanges();
            }

            

        }
        /// <summary>
        /// Get item 
        /// </summary>
        /// <returns>json</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItem()
        {
            return await _context.TodoItems.ToListAsync();
        }
        /// <summary>
        /// get item with id
        /// </summary>
        /// <param name="id">id </param>
        /// <returns>json</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            return todoItem;
        }
        /// <summary>
        /// Create new item and put in database
        /// </summary>
        /// <param name="todoItem">Item Name</param>
        /// <returns>Item</returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
        }

        /// <summary>
        /// Using for Editing Items in database
        /// </summary>
        /// <param name="id">id of item</param>
        /// <param name="todoItem">New Name</param>
        /// <returns>new name</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> PutTodoItem(long id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }
            _context.Entry(todoItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        /// <summary>
        /// Delete Item from Database
        /// </summary>
        /// <param name="id">id of item</param>
        /// <returns>id</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoItem>> DeleteTodoItem(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();
            return todoItem;
        }
        

    }
}
