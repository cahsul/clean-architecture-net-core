using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.X.Extensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared.Role.Queries.GetRoles;
using Shared.X.Responses;

namespace Application.Role.Queries.GetRoles
{
    public class GetRolesQuery : GetRolesRequest, IRequest<ResponseBuilder<List<GetRolesResponse>>>
    {

    }

    public class Handler : IRequestHandler<GetRolesQuery, ResponseBuilder<List<GetRolesResponse>>>
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public Handler(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<ResponseBuilder<List<GetRolesResponse>>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {

            var data = _roleManager.Roles
                .Select(s => new GetRolesResponse
                {
                    Id = Guid.Parse(s.Id),
                    RoleName = s.Name,
                }).ToList();

            return data.ResponseRead();

        }
    }
}
