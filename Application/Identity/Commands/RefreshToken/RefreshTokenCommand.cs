using MediatR;
using Shared.X.Exceptions;
using Shared.X.Responses;
using Shared.Identity.Commands.RefreshToken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.X.Interfaces.Jwt;
using Application.X.Extensions;
using Application.X.Interfaces.Persistence;

namespace Application.Identity.Commands.RefreshToken
{
    public class RefreshTokenCommand : RefreshTokenRequest, IRequest<ResponseBuilder<RefreshTokenResponse>>
    {

    }

    public class Handler : IRequestHandler<RefreshTokenCommand, ResponseBuilder<RefreshTokenResponse>>
    {
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IIdentityDbContext _identityDbContext;

        public Handler(IJwtGenerator jwtGenerator, IIdentityDbContext identityDbContext)
        {
            _jwtGenerator = jwtGenerator;
            _identityDbContext = identityDbContext;
        }

        public async Task<ResponseBuilder<RefreshTokenResponse>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            // https://github.com/cornflourblue/dotnet-5-jwt-refresh-tokens-api/blob/master/Services/UserService.cs

            // get active refresh token
            var refreshToken = _identityDbContext.RefreshTokens
                .Where(w => w.UserId == request.UserId && w.JwtToken == request.JwtToken && w.Token == request.RefreshToken).ToList()
                .Where(w => w.IsActive == true).ToList();

            // return if data not found
            if (!refreshToken.Any())
            {
                throw new BadRequestException("Refresh Token Failed.");
            }

            // update UsedDate
            refreshToken.Select(s => { s.UsedDate = DateTimeOffset.UtcNow; s.ReplacedByToken = request.RefreshToken; return s; }).ToList();
            _identityDbContext.RefreshTokens.UpdateRange(refreshToken);
            await _identityDbContext.SaveChangesAsync(cancellationToken);


            // TODO : if (refreshToken.IsRevoked)
            // TODO : if (!refreshToken.IsActive)
            // TODO : 
            // TODO : 
            // TODO : 


            // create claim
            var claims = new[]
            {
                new Claim("Email", "query.Email"),
                new Claim(ClaimTypes.NameIdentifier, request.UserId),

				//  menu akses
				new Claim("MenuAccess", "Todo.List"),
                new Claim("MenuAccess", "Todo.Create"),
                new Claim("MenuAccess", "Todo.Delete"),

            };

            // create JWT
            var jwtToken = await _jwtGenerator.GetToken(claims, request.UserId);

            return new RefreshTokenResponse
            {
                Token = jwtToken.Token,
                ValidTo = jwtToken.ValidTo,
                RefreshToken = jwtToken.RefreshToken,
            }.ResponseCreate();

        }
    }
}
