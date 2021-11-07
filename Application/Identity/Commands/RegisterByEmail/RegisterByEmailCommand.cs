using Application.X.Interfaces.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared.X.Exceptions;
using Shared.X.Responses;
using Shared.Identity.Commands.RegisterByEmail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.X.Extensions;
using Shared.X.Resources;

namespace Application.Identity.Commands.RegisterByEmail
{
    public class RegisterByEmailCommand : RegisterByEmailRequest, IRequest<ResponseBuilder<RegisterByEmailResponse>>
    {

    }

    public class Handler : IRequestHandler<RegisterByEmailCommand, ResponseBuilder<RegisterByEmailResponse>>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public Handler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ResponseBuilder<RegisterByEmailResponse>> Handle(RegisterByEmailCommand request, CancellationToken cancellationToken)
        {
            // build user data
            var identityUser = new IdentityUser
            {
                Email = request.Email,
                UserName = request.Email,
            };

            // create user
            var result = await _userManager.CreateAsync(identityUser, request.Password);

            // return error
            if (!result.Succeeded)
            {
                // karena menggunakan email, maka setiap error username rubah ke EMAIL
                throw new BadRequestException(result.Errors.Select(s => s.Description.Replace("Username '", "Email '")));
            }

            // get user
            var user = await _userManager.FindByEmailAsync(request.Email);

            return new RegisterByEmailResponse
            {
                Id = user.Id
            }.Response(ResponseLang.Response_RegistrationSuccessful);

        }
    }
}
