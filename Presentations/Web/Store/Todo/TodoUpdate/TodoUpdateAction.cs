using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Store.Todo.TodoUpdate
{
    public class TodoUpdateAction
    {
        public readonly Guid TodoId;

        public TodoUpdateAction(Guid todoId)
        {
            TodoId = todoId;
        }
    }
}
