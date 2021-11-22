using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.X.Extensions;
using Application.X.Interfaces.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared.User.Commands.DeleteUser;
using Shared.X.Responses;

namespace Application.User.Commands.DeleteUser
{

    public class DeleteUserCommand : DeleteUserRequest, IRequest<ResponseBuilder<DeleteUserResponse>>
    {
    }

    public class Handler : IRequestHandler<DeleteUserCommand, ResponseBuilder<DeleteUserResponse>>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public Handler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ResponseBuilder<DeleteUserResponse>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {

            var user = await _userManager.FindByIdAsync(request.Id);
            var result = await _userManager.DeleteAsync(user);

            return new DeleteUserResponse
            {
                Id = user.Id,
            }.ResponseDelete();
        }
    }
}
