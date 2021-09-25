using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Todos.Commands.UpdateTodo
{

    public class UpdateTodoValidator : AbstractValidator<UpdateTodoRequest>
    {
        public UpdateTodoValidator()
        {
            RuleFor(r => r.Title).NotEmpty();
        }
    }
}


