using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Shared.Todos.Commands.CreateTodo
{
    public class CreateTodoRequest
    {
        public string Title { get; set; }
    }

    public class CreateTodoRequestValidator : AbstractValidator<CreateTodoRequest>
    {
        public CreateTodoRequestValidator()
        {
            RuleFor(r => r.Title).NotEmpty().EmailAddress();
        }
    }
}
