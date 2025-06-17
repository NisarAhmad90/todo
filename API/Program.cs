
using Microsoft.EntityFrameworkCore;
using TodoApp.Application.Interfaces;
using TodoApp.Application.Services;
using TodoApp.Infrastructure.Data;
using TodoApp.Infrastructure.Repositories;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<TodoDbContext>(options =>
                options.UseSqlite("Data Source=todo.db"));

            builder.Services.AddScoped<ITodoTaskRepository, TodoTaskRepository>();
            builder.Services.AddScoped<TodoTaskService>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
                
            });

            var app = builder.Build();

            app.UseCors("AllowAll");
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
