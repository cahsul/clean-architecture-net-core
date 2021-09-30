using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application._.Interfaces.Persistence;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Todos.Commands.CreateTodo
{
    public class CreateTodoValidator : AbstractValidator<CreateTodoCommand>
    {
        private readonly ITodoDbContext _todoDbContext;
        public CreateTodoValidator(ITodoDbContext todoDbContext)
        {
            _todoDbContext = todoDbContext;

            When(r => !string.IsNullOrEmpty(r.Title), () =>
            {
                RuleFor(r => r.Title)
                .MustAsync((command, value, ctx, a) => CheckDuplicateAsync(command, value, ctx, a)).WithMessage("_");
            });
        }

        private async Task<bool> CheckDuplicateAsync(CreateTodoCommand command, string value, ValidationContext<CreateTodoCommand> ctx, CancellationToken a)
        {
            // find data by ID
            var data = await _todoDbContext.Todos.FirstOrDefaultAsync(w => w.Title.ToLower() == command.Title.ToLower());

            if (data != null)
            {
                ctx.AddFailure(" Tidak dapat membuat data yang sama ");
                return false;
            }
            return true;
        }



    }
}
