using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.Services;
using TodoApp.Domain.Entities;

namespace TodoApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoTasksController : ControllerBase
    {
        private readonly TodoTaskService _service;

        public TodoTasksController(TodoTaskService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => 
            Ok(await _service.GetAllAsync());

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TodoTask task)
        {
            try
            {
                await _service.AddAsync(task);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TodoTask task)
        {
            if (id != task.Id) return BadRequest("Invalid ID");

            try
            {
                await _service.UpdateAsync(task);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }

        [HttpPut("{id}/toggle")]
        public async Task<IActionResult> Toggle(int id)
        {
            try
            {
                await _service.ToggleCompletionAsync(id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Task not found");
            }
        }
    }
}