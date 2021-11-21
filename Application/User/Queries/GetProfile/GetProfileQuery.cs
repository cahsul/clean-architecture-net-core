using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.X.Attributes;
using Application.X.Extensions;
using Application.X.Interfaces;
using Application.X.Interfaces.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared.User.Queries.GetProfile;
using Shared.X.Exceptions;
using Shared.X.Responses;

namespace Application.User.Queries.GetProfile
{
    //[Authorize("Profile", "List")]
    public class GetProfileQuery : GetProfileRequest, IRequest<ResponseBuilder<GetProfileResponse>>
    {

    }

    public class Handler : IRequestHandler<GetProfileQuery, ResponseBuilder<GetProfileResponse>>
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUser _user;
        public Handler(UserManager<IdentityUser> userManager, IUser user)
        {
            _userManager = userManager;
            _user = user;
        }

        public async Task<ResponseBuilder<GetProfileResponse>> Handle(GetProfileQuery request, CancellationToken cancellationToken)
        {
            // id from cookie and client must be same
            //if (request.UserId != _user.UserId)
            //{
            //    throw new UnauthorizedAccessException("User Not Found");
            //}

            // get user profile by user ID
            var userProfile = await _userManager.FindByIdAsync(_user.UserId);

            return new GetProfileResponse
            {
                Email = userProfile.Email
            }.Response();
        }

    }
}
