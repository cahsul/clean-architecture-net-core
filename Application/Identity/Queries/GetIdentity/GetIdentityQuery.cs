using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.X.Extensions;
using Application.X.Interfaces.Identity;
using Application.X.Interfaces.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared.Identity.Queries.GetIdentity;
using Shared.X.Responses;

namespace Application.Identity.Queries.GetIdentity
{

    public class GetIdentityQuery : GetIdentityRequest, IRequest<ResponseBuilder<GetIdentityResponse>>
    {

    }

    public class Handler : IRequestHandler<GetIdentityQuery, ResponseBuilder<GetIdentityResponse>>
    {
        private readonly IIdentity _identity;
        private readonly IIdentityDbContext _identityDbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public Handler(IIdentity identity, IIdentityDbContext identityDbContext, UserManager<IdentityUser> userManager)
        {
            _identity = identity;
            _identityDbContext = identityDbContext;
            _userManager = userManager;
        }

        public async Task<ResponseBuilder<GetIdentityResponse>> Handle(GetIdentityQuery query, CancellationToken cancellationToken)
        {
            // get user by refresh token
            var refreshToken = _identityDbContext.RefreshTokens.FirstOrDefault(w => w.Token == _identity.RefreshToken);

            var user = await _userManager.FindByIdAsync(refreshToken.UserId.ToString());

            return new GetIdentityResponse
            {
                Email = user.Email

            }.Response();
        }

    }
}
