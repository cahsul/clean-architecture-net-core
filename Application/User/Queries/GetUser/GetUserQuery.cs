using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.X.Extensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared.User.Queries.GetUser;
using Shared.X.Responses;

namespace Application.User.Queries.GetUser
{
    public class GetUserQuery : GetUserRequest, IRequest<ResponseBuilder<GetUserResponse>>
    {

    }

    public class Handler : IRequestHandler<GetUserQuery, ResponseBuilder<GetUserResponse>>
    {
        private readonly UserManager<IdentityUser> _userManager;
        public Handler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ResponseBuilder<GetUserResponse>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var data = _userManager.Users
                .Where(w => w.Id == request.Id)
                .Select(s => new GetUserResponse
                {
                    Email = s.Email,
                    Id = Guid.Parse(s.Id),
                }).FirstOrDefault();

            return data.ResponseRead();
        }
    }
}
