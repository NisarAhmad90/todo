using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Application.Interfaces;
using TodoApp.Domain.Entities;
using TodoApp.Infrastructure.Data;

namespace TodoApp.Infrastructure.Repositories
{
    public class TodoTaskRepository : ITodoTaskRepository
    {
        private readonly TodoDbContext _context;

        public TodoTaskRepository(TodoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoTask>> GetAllAsync() => await _context.TodoTasks.ToListAsync();

        public async Task<TodoTask?> GetByIdAsync(int id) => await _context.TodoTasks.FindAsync(id);

        public async Task AddAsync(TodoTask task)
        {
            _context.TodoTasks.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TodoTask task)
        {
            _context.TodoTasks.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var task = await _context.TodoTasks.FindAsync(id);
            if (task != null)
            {
                _context.TodoTasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
    }
}

