using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Domain.Entities
{
    public class TodoTask
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime? Deadline { get; set; }
        public bool IsCompleted { get; set; }
    }
}
