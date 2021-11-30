﻿using Application.Identity.Commands.RefreshToken;
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
using Shared.Identity.Resources;
using Shared.Identity.Queries.GetToken;
using Application.X.Interfaces.Identity;
using Application.Identity.Queries.GetIdentity;
using Shared.Identity.Queries.GetIdentity;

namespace Serti.Server.Controllers
{

    /// <summary>
    /// seluruh proses dari registrai, login, logout ada disini semua
    /// </summary>
    /// 
    public class IdentityController : ApiController
    {
        private readonly IIdentity _identity;

        public IdentityController(IIdentity identity)
        {
            _identity = identity;
        }

        /// <summary>
        /// register by email
        /// </summary>
        [HttpPost(IdentityEndpoint.Identity.Register)]
        public async Task<ActionResult<ResponseBuilder<RegisterByEmailResponse>>> RegisterByEmail([FromBody] RegisterByEmailCommand query)
        {
            return await Mediator.Send(query);
        }

        /// <summary>
        /// Login By Email
        /// </summary>
        [HttpPost(IdentityEndpoint.Identity.Login)]
        public async Task<ActionResult<ResponseBuilder<LoginByEmailResponse>>> LoginByEmail([FromBody] LoginByEmailQuery query)
        {
            var response = await Mediator.Send(query);
            SetTokenCookie(response.Data.JwtToken, response.Data.RefreshToken);
            return response;
        }

        [HttpPost(IdentityEndpoint.Identity.RefreshToken)]
        public async Task<ActionResult<ResponseBuilder<RefreshTokenResponse>>> RefreshToken([FromBody] RefreshTokenCommand q)
        {
            var response = await Mediator.Send(q);
            SetTokenCookie(response.Data.Token, response.Data.RefreshToken);
            return response;
        }

        [HttpPost(IdentityEndpoint.Identity.GetToken)]
        public async Task<ActionResult<ResponseBuilder<GetTokenResponse>>> GetToken()
        {
            var rtn = new ResponseBuilder<GetTokenResponse>
            {
                Data = new GetTokenResponse
                {
                    JwtToken = Request.Cookies["JwtToken"],
                    RefreshToken = Request.Cookies["RefreshToken"],
                }
            };
            return rtn;
        }

        [HttpPost(IdentityEndpoint.Identity.GetIdentity)]
        public async Task<ActionResult<ResponseBuilder<GetIdentityResponse>>> GetIdentity()
        {
            var response = await Mediator.Send(new GetIdentityQuery());
            return response;
        }

        private void SetTokenCookie(string jwtToken, string refreshToken)
        {

            _identity.JwtToken = jwtToken;
            _identity.RefreshToken = refreshToken;

            //Response.Cookies.Append("JwtToken", jwtToken, new CookieOptions
            //{
            //    HttpOnly = true,
            //    Expires = DateTime.UtcNow.AddDays(7),

            //});

            //Response.Cookies.Append("RefreshToken", refreshToken, new CookieOptions
            //{
            //    HttpOnly = true,
            //    Expires = DateTime.UtcNow.AddDays(7)
            //});
        }


    }
}