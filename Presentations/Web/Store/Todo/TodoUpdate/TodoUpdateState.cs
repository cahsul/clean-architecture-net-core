using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Store.Todo.TodoUpdate
{

    public class TodoUpdateState
    {
        public Guid TodoId { get; }

        public TodoUpdateState(Guid todoId)
        {
            TodoId = todoId;
        }

    }
}
