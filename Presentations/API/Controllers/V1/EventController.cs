using Application.Event.Commands.EventCreate;
using Microsoft.AspNetCore.Mvc;
using Shared._.Responses;
using Shared.Event.Commands.EventCreate;
using Shared.Event.Resources;
using System.Threading.Tasks;

namespace API.Controllers.V1
{
    /// <summary>
    /// pembuatan event
    /// </summary>
    [ApiVersion("1")]
    public class EventController : ApiV1Controller
    {
        ///// <summary>
        ///// get todo list
        ///// </summary>
        //[HttpGet(TodoEndpoint.V1.Todo.EndPoint)]
        //[ProducesResponseType(201)]
        //[ProducesResponseType(400)]
        //[Produces(typeof(ResponseBuilder<List<GetTodosResponse>>))]
        //public async Task<ActionResult<ResponseBuilder<List<GetTodosResponse>>>> Get(GetTodosQuery query)
        //{
        //    var ggg = User.Identity.AuthenticationType;

        //    return await Mediator.Send(query);
        //}

        /// <summary>
        /// Create
        /// </summary>
        [HttpPost(EventEndpoint.V1.Event.Create.EndPoint)]
        [Produces(typeof(ResponseBuilder<EventCreateResponse>))]
        public async Task<ActionResult<ResponseBuilder<EventCreateResponse>>> Create([FromBody] EventCreateCommand query)
        {
            return await Mediator.Send(query);
        }


        ///// <summary>
        ///// Delete
        ///// </summary>
        //[HttpDelete(TodoEndpoint.V1.Todo.Delete.EndPoint)]
        //[Produces(typeof(ResponseBuilder<DeleteTodoResponse>))]
        //public async Task<ActionResult<ResponseBuilder<DeleteTodoResponse>>> Delete(DeleteTodoCommand query)
        //{
        //    return await Mediator.Send(query);
        //}

        ///// <summary>
        ///// Update
        ///// </summary>
        //[HttpPut(TodoEndpoint.V1.Todo.Update.EndPoint)]
        //[Produces(typeof(ResponseBuilder<UpdateTodoResponse>))]
        //public async Task<ActionResult<ResponseBuilder<UpdateTodoResponse>>> Update(UpdateTodoCommand query)
        //{
        //    return await Mediator.Send(query);
        //}
    }
}
