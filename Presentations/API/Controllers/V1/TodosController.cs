using Application.Todos.Commands.CreateTodo;
using Application.Todos.Commands.DeleteTodo;
using Application.Todos.Commands.UpdateTodo;
using Application.Todos.Queries.GetTodos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared._.Responses;
using Shared.Todos.Commands.CreateTodo;
using Shared.Todos.Commands.DeleteTodo;
using Shared.Todos.Commands.UpdateTodo;
using Shared.Todos.Queries.GetTodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers.V1
{
    /// <summary>
    /// aplikasi todo list
    /// </summary>
    [ApiVersion("1")]
    public class TodosController : ApiV1Controller
    {
        /// <summary>
        /// get todo list
        /// </summary>
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [HttpGet]
        [Produces(typeof(ResponseBuilder<List<GetTodosResponse>>))]
        public async Task<ActionResult<ResponseBuilder<List<GetTodosResponse>>>> Get(GetTodosQuery query)
        {
            var ggg = User.Identity.AuthenticationType;

            return await Mediator.Send(query);
        }

        /// <summary>
        /// Create
        /// </summary>
        [HttpPost]
        [Produces(typeof(ResponseBuilder<CreateTodoResponse>))]
        public async Task<ActionResult<ResponseBuilder<CreateTodoResponse>>> Create(CreateTodoCommand query)
        {
            return await Mediator.Send(query);
        }


        /// <summary>
        /// Delete
        /// </summary>
        [HttpDelete("{Id:guid}")]
        [Produces(typeof(ResponseBuilder<DeleteTodoResponse>))]
        public async Task<ActionResult<ResponseBuilder<DeleteTodoResponse>>> Delete(DeleteTodoCommand query)
        {
            return await Mediator.Send(query);
        }

        /// <summary>
        /// Update
        /// </summary>
        [HttpPut("{Id:guid}")]
        [Produces(typeof(ResponseBuilder<UpdateTodoResponse>))]
        public async Task<ActionResult<ResponseBuilder<UpdateTodoResponse>>> Update(UpdateTodoCommand query)
        {
            return await Mediator.Send(query);
        }
    }
}
