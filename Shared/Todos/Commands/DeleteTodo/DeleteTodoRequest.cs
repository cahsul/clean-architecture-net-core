using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Todos.Commands.DeleteTodo
{
    public class DeleteTodoRequest
    {
        public Guid Id { get; set; }
    }
}
