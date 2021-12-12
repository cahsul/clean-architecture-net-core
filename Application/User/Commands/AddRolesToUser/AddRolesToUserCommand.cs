using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.X.Extensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared.User.Commands.AddRolesToUser;
using Shared.X.Responses;

namespace Application.User.Commands.AddRolesToUser
{

    public class AddRolesToUserCommand : AddRolesToUserRequest, IRequest<ResponseBuilder<AddRolesToUserResponse>>
    {
    }

    public class Handler : IRequestHandler<AddRolesToUserCommand, ResponseBuilder<AddRolesToUserResponse>>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public Handler(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<ResponseBuilder<AddRolesToUserResponse>> Handle(AddRolesToUserCommand request, CancellationToken cancellationToken)
        {

            var rolesName = new List<string>();


            // find user by ID
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());

            // TODO : user validasi

            // find roles name by ID
            foreach (var item in request.Roles)
            {
                var role = await _roleManager.FindByIdAsync(item.ToString());
                if (role != null)
                {
                    rolesName.Add(role.Name);
                }
            }

            // add roles to user
            await _userManager.AddToRolesAsync(user, rolesName);

            return new AddRolesToUserResponse { }.ResponseCreate();
        }
    }
}
