using Application.Todos.Commands.CreateTodo;
using Application.Todos.Commands.DeleteTodo;
using Application.Todos.Commands.UpdateTodo;
using Application.Todos.Queries.GetTodos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.X.Responses;
using Shared.Todos.Commands.CreateTodo;
using Shared.Todos.Commands.DeleteTodo;
using Shared.Todos.Commands.UpdateTodo;
using Shared.Todos.Queries.GetTodos;
using Shared.Todos.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Serti.Server.Controllers
{
    /// <summary>
    /// aplikasi todo list
    /// </summary>
    //[ApiVersion("1")]
    public class TodoController : ApiController
    {
        /// <summary>
        /// get todo list
        /// </summary>
        [HttpGet(TodoEndpoint.V1.Todo.EndPoint)]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [Produces(typeof(ResponseBuilder<List<GetTodosResponse>>))]
        public async Task<ActionResult<ResponseBuilder<List<GetTodosResponse>>>> Get(GetTodosQuery query)
        {
            var ggg = User.Identity.AuthenticationType;

            return await Mediator.Send(query);
        }

        /// <summary>
        /// Create
        /// </summary>
        [HttpPost(TodoEndpoint.V1.Todo.Create.EndPoint)]
        [Produces(typeof(ResponseBuilder<CreateTodoResponse>))]
        public async Task<ActionResult<ResponseBuilder<CreateTodoResponse>>> Create([FromBody] CreateTodoCommand query)
        {
            return await Mediator.Send(query);
        }


        /// <summary>
        /// Delete
        /// </summary>
        [HttpDelete(TodoEndpoint.V1.Todo.Delete.EndPoint)]
        [Produces(typeof(ResponseBuilder<DeleteTodoResponse>))]
        public async Task<ActionResult<ResponseBuilder<DeleteTodoResponse>>> Delete(DeleteTodoCommand query)
        {
            return await Mediator.Send(query);
        }

        /// <summary>
        /// Update
        /// </summary>
        [HttpPut(TodoEndpoint.V1.Todo.Update.EndPoint)]
        [Produces(typeof(ResponseBuilder<UpdateTodoResponse>))]
        public async Task<ActionResult<ResponseBuilder<UpdateTodoResponse>>> Update(UpdateTodoCommand query)
        {
            return await Mediator.Send(query);
        }
    }
}
