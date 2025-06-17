using Microsoft.EntityFrameworkCore;
using TodoApp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace TodoApp.Infrastructure.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) { }
        public DbSet<TodoTask> TodoTasks { get; set; }
    }
}
