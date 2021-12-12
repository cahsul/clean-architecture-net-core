using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.X.Extensions;
using Application.X.Interfaces.Identity;
using MediatR;
using Shared.Identity.Queries.Logout;
using Shared.X.Responses;

namespace Application.Identity.Queries.Logout
{

    public class LogoutQuery : LogoutRequest, IRequest<ResponseBuilder<LogoutResponse>>
    {

    }

    public class Handler : IRequestHandler<LogoutQuery, ResponseBuilder<LogoutResponse>>
    {
        private readonly IIdentity _identity;

        public Handler(IIdentity identity)
        {
            _identity = identity;
        }

        public async Task<ResponseBuilder<LogoutResponse>> Handle(LogoutQuery query, CancellationToken cancellationToken)
        {
            // todo : revoke token
            _identity.Logout();


            return new LogoutResponse
            {
            }.Response("Logout Successfully");
        }
    }
}
