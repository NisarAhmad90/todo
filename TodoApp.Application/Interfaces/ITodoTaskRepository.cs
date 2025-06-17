using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Interfaces
{
    public interface ITodoTaskRepository
    {
        Task<IEnumerable<TodoTask>> GetAllAsync();
        Task<TodoTask?> GetByIdAsync(int id);
        Task AddAsync(TodoTask task);
        Task UpdateAsync(TodoTask task);
        Task DeleteAsync(int id);
    }
}
