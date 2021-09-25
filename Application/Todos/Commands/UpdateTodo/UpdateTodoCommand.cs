using Application._.Extensions;
using Application._.Interfaces.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared._.Responses;
using Shared.Todos.Commands.UpdateTodo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Todos.Commands.UpdateTodo
{
    public class UpdateTodoCommand : UpdateTodoRequest, IRequest<ResponseBuilder<UpdateTodoResponse>>
    {
    }

    public class Handler : IRequestHandler<UpdateTodoCommand, ResponseBuilder<UpdateTodoResponse>>
    {
        private readonly ITodoDbContext _todoDbContext;

        public Handler(ITodoDbContext todoDbContext)
        {
            _todoDbContext = todoDbContext;
        }

        public async Task<ResponseBuilder<UpdateTodoResponse>> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            // find data by ID
            var dataToDelete = await _todoDbContext.Todos.FirstOrDefaultAsync(w => w.Id == request.Id);

            // update data
            dataToDelete.Title = request.Title;

            _todoDbContext.Todos.Update(dataToDelete);
            await _todoDbContext.SaveChangesAsync();

            return new UpdateTodoResponse
            {
                Id = dataToDelete.Id,
            }.Response();
        }
    }
}
