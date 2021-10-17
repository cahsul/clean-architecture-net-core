using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.X.Responses;
using Shared.Todos.Commands.DeleteTodo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.X.Extensions;
using Application.X.Interfaces.Persistence;

namespace Application.Todos.Commands.DeleteTodo
{
    public class DeleteTodoCommand : DeleteTodoRequest, IRequest<ResponseBuilder<DeleteTodoResponse>>
    {
    }

    public class Handler : IRequestHandler<DeleteTodoCommand, ResponseBuilder<DeleteTodoResponse>>
    {
        private readonly ITodoDbContext _todoDbContext;

        public Handler(ITodoDbContext todoDbContext)
        {
            _todoDbContext = todoDbContext;
        }

        public async Task<ResponseBuilder<DeleteTodoResponse>> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
            // find data by ID
            var dataToDelete = await _todoDbContext.Todos.FirstOrDefaultAsync(w => w.Id == request.Id);

            // delete data
            _todoDbContext.Todos.Remove(dataToDelete);
            await _todoDbContext.SaveChangesAsync();

            return new DeleteTodoResponse
            {
                Id = dataToDelete.Id,
            }.Response();
        }
    }
}
