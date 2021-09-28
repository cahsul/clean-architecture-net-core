using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;

namespace Web.Store.Todo.TodoUpdate
{
    public class TodoUpdateFeature : Feature<TodoUpdateState>
    {
        public override string GetName()
        {
            return "TodoUpdate";
        }

        protected override TodoUpdateState GetInitialState()
        {
            return new(Guid.Empty);
        }
    }
}
