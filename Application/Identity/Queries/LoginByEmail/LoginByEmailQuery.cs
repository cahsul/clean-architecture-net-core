using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shared.X.Exceptions;
using Shared.Identity.Queries.LoginByEmail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Shared.X.Enums;
using Shared.X.Responses;
using Shared.X.Extensions;
using Application.X.Interfaces.Jwt;
using Application.X.Extensions;
using Application.X.Interfaces.Persistence;
using Shared.X.Resources;

namespace Application.Identity.Queries.LoginByEmail
{

    public class LoginByEmailQuery : LoginByEmailRequest, IRequest<ResponseBuilder<LoginByEmailResponse>>
    {

    }

    public class Handler : IRequestHandler<LoginByEmailQuery, ResponseBuilder<LoginByEmailResponse>>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IIdentityDbContext _identityDbContext;

        public Handler(UserManager<IdentityUser> userManager, IJwtGenerator jwtGenerator, IIdentityDbContext identityDbContext)
        {
            _userManager = userManager;
            _jwtGenerator = jwtGenerator;
            _identityDbContext = identityDbContext;
        }

        public async Task<ResponseBuilder<LoginByEmailResponse>> Handle(LoginByEmailQuery query, CancellationToken cancellationToken)
        {
            // get user
            var user = await _userManager.FindByEmailAsync(query.Email);

            // check password
            var checkPassword = await _userManager.CheckPasswordAsync(user, query.Password);

            if (!checkPassword)
            {
                throw new BadRequestException(ResponseLang.Response_LoginFailed);
            }

            // create claim
            var claims = new[]
            {
                new Claim("Email", query.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id),

				//  menu akses
				new Claim("MenuAccess", "Todo.List"),
                new Claim("MenuAccess", "Todo.Create"),
                new Claim("MenuAccess", "Todo.Delete"),

            };

            await RevokeRefreshToken(user);

            // create JWT
            var jwtToken = await _jwtGenerator.GetToken(claims, user.Id);


            return new LoginByEmailResponse
            {
                //UserId = user.Id,
                JwtToken = jwtToken.Token,
                //ValidTo = jwtToken.ValidTo,
                RefreshToken = jwtToken.RefreshToken,
            }.Response("Login Successfully");
        }

        /// <summary>
        /// sebelum membuat jwt, revoke semua refresh token agar tidak dapat digunakan lagi
        /// </summary>
        private async Task RevokeRefreshToken(IdentityUser user)
        {
            // get refresh token by user id
            var refreshToken = await _identityDbContext.RefreshTokens.Where(w => w.UserId == user.Id)
                .ToListAsync();

            // revoke semua 
            if (refreshToken.Any())
            {
                var refreshTokenActive = refreshToken.Where(w => w.IsActive == true)
                    .Select(s =>
                    {
                        s.RevokedDate = DateTimeOffset.UtcNow;
                        s.ReasonRevoked = ReasonRevoked.loginProcess.GetDescription();
                        return s;
                    }).ToList();

                _identityDbContext.RefreshTokens.UpdateRange(refreshTokenActive);
                await _identityDbContext.SaveChangesAsync();
            }

        }
    }
}
