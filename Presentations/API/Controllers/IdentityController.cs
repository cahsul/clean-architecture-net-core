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

namespace API.Controllers
{

    /// <summary>
    /// seluruh proses dari registrai, login, logout ada disini semua
    /// </summary>
	public class IdentityController : ApiController
    {


        /// <summary>
        /// register by email
        /// </summary>
        [HttpPost("Register")]
        [Produces(typeof(ResponseBuilder<RegisterByEmailResponse>))]
        public async Task<ActionResult<ResponseBuilder<RegisterByEmailResponse>>> RegisterByEmail(RegisterByEmailCommand query)
        {
            return await Mediator.Send(query);
        }

        /// <summary>
        /// Login By Email
        /// </summary>
        [HttpPost("Login")]
        [Produces(typeof(ResponseBuilder<LoginByEmailResponse>))]
        public async Task<ActionResult<ResponseBuilder<LoginByEmailResponse>>> LoginByEmail(LoginByEmailQuery query)
        {
            var response = await Mediator.Send(query);
            SetTokenCookie(response.Data.RefreshToken);
            return response;
        }

        [HttpPost("RefreshToken")]
        [Produces(typeof(ResponseBuilder<RefreshTokenResponse>))]
        public async Task<ActionResult<ResponseBuilder<RefreshTokenResponse>>> RefreshToken(RefreshTokenCommand q)
        {
            var refreshToken = Request.Cookies["refreshToken"];

            var response = await Mediator.Send(q);
            SetTokenCookie(response.Data.RefreshToken);
            return response;
        }


        private void SetTokenCookie(string refreshToken)
        {
            // append cookie with refresh token to the http response
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        }
    }
}
