using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.X.Attributes;
using Application.X.Extensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared.User.Queries.GetUsers;
using Shared.X.Responses;

namespace Application.User.Queries.GetUsers
{

    [Authorize("Todo", "List")]
    public class GetUsersQuery : GetUsersRequest, IRequest<ResponseBuilder<List<GetUsersResponse>>>
    {

    }

    public class Handler : IRequestHandler<GetUsersQuery, ResponseBuilder<List<GetUsersResponse>>>
    {
        private readonly UserManager<IdentityUser> _userManager;
        public Handler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ResponseBuilder<List<GetUsersResponse>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var data = _userManager.Users
                .Select(s => new GetUsersResponse
                {
                    Email = s.Email,
                    Id = Guid.Parse(s.Id),
                }).ToList();

            return data.ResponseRead();
        }
    }
}
