using Domain.Entities;
using MediatR;
using Shared.X.Responses;
using Shared.Todos.Commands.CreateTodo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.Todo;
using Application.X.Extensions;
using Application.X.Interfaces.Persistence;

namespace Application.Todos.Commands.CreateTodo
{

    public class CreateTodoCommand : CreateTodoRequest, IRequest<ResponseBuilder<CreateTodoResponse>>
    {
    }

    public class Handler : IRequestHandler<CreateTodoCommand, ResponseBuilder<CreateTodoResponse>>
    {
        private readonly ITodoDbContext _todoDbContext;

        public Handler(ITodoDbContext todoDbContext)
        {
            _todoDbContext = todoDbContext;
        }

        public async Task<ResponseBuilder<CreateTodoResponse>> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            // save
            var dataToSave = new Todo
            {
                Title = request.Title,
            };

            await _todoDbContext.Todos.AddAsync(dataToSave);
            await _todoDbContext.SaveChangesAsync();


            return new CreateTodoResponse
            {
                Id = dataToSave.Id,
            }.Response();
        }
    }
}
