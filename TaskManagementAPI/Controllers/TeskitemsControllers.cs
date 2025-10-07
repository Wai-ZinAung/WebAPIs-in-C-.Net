using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.DAO;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeskitemsControllers : ControllerBase
    {
        private readonly AppDbContext _context;

        public TeskitemsControllers(AppDbContext context)
        {
            this._context = context;
        }

        //get all task items
        [HttpGet]
        public IActionResult GetAllTaskItems()
        {
            var taskItems = _context.TaskItems.ToList();
            return Ok(taskItems);
        }
        //get task item by id
        [HttpGet("{id}")]
        public IActionResult GetTaskItemById(int id)
        {
            var taskItem = _context.TaskItems.Find(id);
            if (taskItem == null)
            {
                return NotFound();
            }
            return Ok(taskItem);
        }
        //create a new task item
        [HttpPost]
        public IActionResult CreateTaskItem([FromBody] TaskItems taskItem)
        {
            if (taskItem == null)
            {
                return BadRequest();
            }
            _context.TaskItems.Add(taskItem);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetTaskItemById), new { id = taskItem.Id }, taskItem);
        }
        //update a task item
        [HttpPut("{id}")]
        public IActionResult UpdateTaskItem(int id, [FromBody] TaskItems taskItem)
        {
            if (taskItem == null || taskItem.Id != id)
                return BadRequest();

            var existingTaskItem = _context.TaskItems.Find(id);
            if (existingTaskItem == null)
                return NotFound();

            existingTaskItem.Title = taskItem.Title;
            existingTaskItem.Description = taskItem.Description;
            existingTaskItem.IsCompleted = taskItem.IsCompleted;

            _context.SaveChanges(); // no need for Update()
            return Ok("Task item updated successfully");
        }
    
        //delete a task item
        [HttpDelete("{id}")]
        public IActionResult DeleteTaskItem(int id)
        {
            var taskItem = _context.TaskItems.Find(id);
            if (taskItem == null)
            {
                return NotFound();
            }
            _context.TaskItems.Remove(taskItem);
            _context.SaveChanges();
            return Ok("Task item deleted successfully");
        }
    }
}