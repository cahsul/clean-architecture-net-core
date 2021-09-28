using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;

namespace Web.Store.Todo.TodoUpdate
{
    public static class TodoUpdateReducer
    {
        [ReducerMethod]
        public static TodoUpdateState ReduceIncrementCounterAction(TodoUpdateState state, TodoUpdateAction action)
        {
            return new(action.TodoId);
        }
    }
}
