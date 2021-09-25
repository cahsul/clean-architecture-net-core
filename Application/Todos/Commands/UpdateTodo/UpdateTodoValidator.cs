using Application._.Interfaces.Persistence;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SharedValidator = Shared.Todos.Commands.UpdateTodo;

namespace Application.Todos.Commands.UpdateTodo
{
    public class UpdateTodoValidator : AbstractValidator<UpdateTodoCommand>
    {
        private readonly ITodoDbContext _todoDbContext;

        public UpdateTodoValidator(ITodoDbContext todoDbContext)
        {
            ;
            _todoDbContext = todoDbContext;
            Include(new SharedValidator.UpdateTodoValidator());

            When(r => !string.IsNullOrEmpty(r.Title), () =>
            {
                RuleFor(r => r.Id)
             .MustAsync((r, name, cancellation) => { return IsNotExist(r, cancellation); }).WithMessage("Data Not Found.");

            });


        }

        public async Task<bool> IsNotExist(UpdateTodoCommand request, CancellationToken cancellationToken)
        {

            // find data by ID
            var data = await _todoDbContext.Todos.FirstOrDefaultAsync(w => w.Id == request.Id);

            if (data == null)
            {
                return false;
            }
            return true;
        }
    }
}
