using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Application.Interfaces;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Services
{
    public class TodoTaskService 
    {
        private readonly ITodoTaskRepository _repository;

        public TodoTaskService(ITodoTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TodoTask>> GetAllAsync()
            => await _repository.GetAllAsync();

        public async Task<TodoTask?> GetByIdAsync(int id)
            => await _repository.GetByIdAsync(id);

        public async Task AddAsync(TodoTask task)
        {
            if (string.IsNullOrWhiteSpace(task.Title) || task.Title.Length <= 10)
                throw new ArgumentException("Task title must be longer than 10 characters.");

            await _repository.AddAsync(task);
        }

        public async Task UpdateAsync(TodoTask task)
        {
            if (string.IsNullOrWhiteSpace(task.Title) || task.Title.Length <= 10)
                throw new ArgumentException("Task title must be longer than 10 characters.");

            await _repository.UpdateAsync(task);
        }

        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);

        public async Task ToggleCompletionAsync(int id)
        {
            var task = await _repository.GetByIdAsync(id);
            if (task == null) throw new KeyNotFoundException();

            task.IsCompleted = !task.IsCompleted;
            await _repository.UpdateAsync(task);
        }
    }
}
