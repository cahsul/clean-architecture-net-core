using Application.Identity.Commands.RefreshToken;
using Application.Identity.Commands.RegisterByEmail;
using Application.Identity.Queries.LoginByEmail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Shared.X.Responses;
using Shared.Identity.Commands.RefreshToken;
using Shared.Identity.Commands.RegisterByEmail;
using Shared.Identity.Queries.LoginByEmail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.User.Resources;
using Application.User.Queries.GetProfile;
using Shared.User.Queries.GetProfile;
using Application.User.Queries.GetUsers;
using Shared.User.Queries.GetUsers;
using Application.User.Queries.GetUser;
using Shared.User.Queries.GetUser;
using Application.User.Commands.DeleteUser;
using Shared.User.Commands.DeleteUser;
using Application.User.Commands.AddRolesToUser;
using Shared.User.Commands.AddRolesToUser;

namespace Serti.Server.Controllers
{

    public class UserController : ApiController
    {

        [HttpGet(UserEndpoint.User.Profile)]
        public async Task<ActionResult<ResponseBuilder<GetProfileResponse>>> GetProfile(GetProfileQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet(UserEndpoint.User.GetUsers)]
        public async Task<ActionResult<ResponseBuilder<List<GetUsersResponse>>>> GetUsers(GetUsersQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet(UserEndpoint.User.GetUser)]
        public async Task<ActionResult<ResponseBuilder<GetUserResponse>>> GetUser(GetUserQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpDelete(UserEndpoint.User.Delete)]
        public async Task<ActionResult<ResponseBuilder<DeleteUserResponse>>> DeleteUser([FromBody] DeleteUserCommand query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost(UserEndpoint.User.SetRole)]
        public async Task<ActionResult<ResponseBuilder<AddRolesToUserResponse>>> AddRolesToUser([FromBody] AddRolesToUserCommand query)
        {
            return await Mediator.Send(query);
        }
    }
}
