using Application.X.Attributes;
using Dapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.X.Responses;
using Shared.Todos.Queries.GetTodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.Todo;
using Application.X.Extensions;
using Application.X.Interfaces.Identity;
using Application.X.Interfaces.Persistence;

namespace Application.Todos.Queries.GetTodos
{

    //[Authorize("Todo", "List")]
    public class GetTodosQuery : IRequest<ResponseBuilder<List<GetTodosResponse>>>
    {

    }

    public class Handler : IRequestHandler<GetTodosQuery, ResponseBuilder<List<GetTodosResponse>>>
    {

        private readonly ITodoDbContext _todoDbContext;
        private readonly ITodoDbContextDapper _dbContextDapper;
        private readonly IIdentity _identity;

        public Handler(ITodoDbContext todoDbContext, IIdentity identity, ITodoDbContextDapper dbContextDapper)
        {
            _todoDbContext = todoDbContext;
            _dbContextDapper = dbContextDapper;
            _identity = identity;
        }

        public async Task<ResponseBuilder<List<GetTodosResponse>>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
        {
            //var todos = await EfCore();
            var todos = await Dapper();

            return todos.Response();
        }

        private async Task<List<GetTodosResponse>> EfCore()
        {
            var todos = await _todoDbContext.Todos
                .Select(s => new GetTodosResponse
                {
                    Title = s.Title,
                    Id = s.Id
                })
                .ToListAsync();

            return todos;
        }

        private async Task<List<GetTodosResponse>> Dapper()
        {
            var query = "SELECT * FROM Todo";
            using var conn = _dbContextDapper.CreateConnection();
            var todos = await conn.QueryAsync<Todo>(query);

            return todos.Select(s => new GetTodosResponse
            {
                Title = s.Title,
                Id = s.Id
            }).ToList();
        }
    }
}
