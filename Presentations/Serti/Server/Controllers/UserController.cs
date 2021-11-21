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

namespace Serti.Server.Controllers
{

    public class UserController : ApiController
    {

        [HttpGet(UserEndpoint.User.Profile)]
        public async Task<ActionResult<ResponseBuilder<GetProfileResponse>>> GetProfile(GetProfileQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
