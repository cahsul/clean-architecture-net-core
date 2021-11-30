using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using Application.X.Interfaces.Identity;
using Application.X.Attributes;
using Application.X.Interfaces.Jwt;
using Application.X.Interfaces.Persistence;
using Shared.X.Exceptions;
using System.Security.Claims;

namespace Application.X.Behaviours
{
    public class AuthorizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IIdentity _identity;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IIdentityDbContext _identityDbContext;

        public AuthorizationBehaviour(IIdentity identity, IJwtGenerator jwtGenerator, IIdentityDbContext identityDbContext)
        {
            _identity = identity;
            _jwtGenerator = jwtGenerator;
            _identityDbContext = identityDbContext;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var authorizeAttributes = request.GetType().GetCustomAttributes<AuthorizeAttribute>();

            if (authorizeAttributes.Any())
            {
                if (!_identity.IsAuthenticated)
                {
                    // cek dahulu ke refresh token. kalau benar benar ndak punya akses langsung tendang aja..
                    var result = await RefreshToken();
                    if (result == false)
                    {
                        throw new UnauthorizedAccessException("Current User is not authenticated."); // TODO : hardcode
                    }

                }

                var authorizeAttributesWithPolicies = authorizeAttributes.Where(a => a.MenuName != null).ToList();

                foreach (var menuName in authorizeAttributesWithPolicies.Select(a => a.MenuName))
                {
                    // action
                    foreach (var actionName in authorizeAttributesWithPolicies.Select(a => a.ActionName))
                    {
                        var menuWithAction = $"{menuName}.{actionName}";
                        var haveMenuAccess = _identity.MenuAccess.Any(x => x.MenuName.ToLower() == menuName.ToLower() && x.ActionName.ToLower() == actionName.ToLower());

                        if (!haveMenuAccess)
                        {

                            var errorMessage = $"{_identity.Email} does not have the following permission: {menuWithAction}";
                            throw new UnauthorizedAccessException(errorMessage);
                        }
                    }


                }
            }

            return await next();
        }

        private async Task<bool> RefreshToken()
        {
            // https://github.com/cornflourblue/dotnet-5-jwt-refresh-tokens-api/blob/master/Services/UserService.cs


            // get active refresh token
            var refreshToken = _identityDbContext.RefreshTokens
                .Where(w => w.JwtToken == _identity.JwtToken && w.Token == _identity.RefreshToken).ToList()
                .Where(w => w.IsActive == true).ToList();

            // return if data not found
            if (!refreshToken.Any())
            {
                return false;
            }

            // update UsedDate
            refreshToken.Select(s => { s.UsedDate = DateTimeOffset.UtcNow; s.ReplacedByToken = _identity.RefreshToken; return s; }).ToList();
            _identityDbContext.RefreshTokens.UpdateRange(refreshToken);
            await _identityDbContext.SaveChangesAsync();

            // create claim
            var claims = new[]
            {
                new Claim("Email", "query.Email"),
                new Claim(ClaimTypes.NameIdentifier, refreshToken[0].UserId),

				//  menu akses
				new Claim("MenuAccess", "Todo.List"),
                new Claim("MenuAccess", "Todo.Create"),
                new Claim("MenuAccess", "Todo.Delete"),

            };

            // create JWT
            var jwtToken = await _jwtGenerator.GetToken(claims, refreshToken[0].UserId);

            _identity.JwtToken = jwtToken.Token;
            _identity.RefreshToken = jwtToken.RefreshToken;

            return true;
        }
    }


}
