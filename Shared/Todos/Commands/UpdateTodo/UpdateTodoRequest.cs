using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Todos.Commands.UpdateTodo
{
    public class UpdateTodoRequest
    {
        public string Title { get; set; }
        public Guid Id { get; set; }
    }
}
