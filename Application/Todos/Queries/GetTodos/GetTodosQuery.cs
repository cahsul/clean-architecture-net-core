using Application._.Attributes;
using Application._.Extensions;
using Application._.Interfaces.Identity;
using Application._.Interfaces.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared._.Responses;
using Shared.Todos.Queries.GetTodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Todos.Queries.GetTodos
{

    //[Authorize("Todo", "List")]
    public class GetTodosQuery : IRequest<ResponseBuilder<List<GetTodosResponse>>>
    {

    }

    public class Handler : IRequestHandler<GetTodosQuery, ResponseBuilder<List<GetTodosResponse>>>
    {

        private readonly ITodoDbContext _todoDbContext;
        private readonly IIdentity _identity;

        public Handler(ITodoDbContext todoDbContext, IIdentity identity)
        {
            _todoDbContext = todoDbContext;
            _identity = identity;
        }

        public async Task<ResponseBuilder<List<GetTodosResponse>>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
        {
            var asdasdasd = _identity;
            var todos = await _todoDbContext.Todos
                .Select(s => new GetTodosResponse
                {
                    Title = s.Title,
                    Id = s.Id
                })
                .ToListAsync(cancellationToken);

            return todos.Response();
        }
    }
}
