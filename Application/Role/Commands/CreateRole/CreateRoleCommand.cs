using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.X.Extensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared.Role.Commands.CreateRole;
using Shared.X.Responses;

namespace Application.Role.Commands.CreateRole
{

    public class CreateRoleCommand : CreateRoleRequest, IRequest<ResponseBuilder<CreateRoleResponse>>
    {
    }

    public class Handler : IRequestHandler<CreateRoleCommand, ResponseBuilder<CreateRoleResponse>>
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public Handler(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<ResponseBuilder<CreateRoleResponse>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var newRole = new IdentityRole { Name = request.RoleName };

            // creaate role
            var role = await _roleManager.CreateAsync(newRole);



            return new CreateRoleResponse
            {
                Id = newRole.Id,
            }.ResponseCreate();
        }
    }
}
