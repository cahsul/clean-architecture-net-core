

using Application.Role.Commands.CreateRole;
using Microsoft.AspNetCore.Mvc;
using Shared.Role.Commands.CreateRole;
using Shared.Role.Resources;
using Shared.X.Responses;

namespace Serti.Server.Controllers
{

    public class RoleController : ApiController
    {
        [HttpPost(RoleEndpoint.Role.Create)]
        public async Task<ActionResult<ResponseBuilder<CreateRoleResponse>>> DeleteUser([FromBody] CreateRoleCommand query)
        {
            return await Mediator.Send(query);
        }


        //[HttpGet(UserEndpoint.User.Profile)]
        //public async Task<ActionResult<ResponseBuilder<GetProfileResponse>>> GetProfile(GetProfileQuery query)
        //{
        //    return await Mediator.Send(query);
        //}

        //[HttpGet(UserEndpoint.User.GetUsers)]
        //public async Task<ActionResult<ResponseBuilder<List<GetUsersResponse>>>> GetUsers(GetUsersQuery query)
        //{
        //    return await Mediator.Send(query);
        //}

        //[HttpGet(UserEndpoint.User.GetUser)]
        //public async Task<ActionResult<ResponseBuilder<GetUserResponse>>> GetUser(GetUserQuery query)
        //{
        //    return await Mediator.Send(query);
        //}

        //[HttpDelete(UserEndpoint.User.Delete)]
        //public async Task<ActionResult<ResponseBuilder<DeleteUserResponse>>> DeleteUser([FromBody] DeleteUserCommand query)
        //{
        //    return await Mediator.Send(query);
        //}
    }
}
