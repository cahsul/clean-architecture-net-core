using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using Application.X.Interfaces.Identity;
using Application.X.Attributes;

namespace Application.X.Behaviours
{
    public class AuthorizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IIdentity _identity;

        public AuthorizationBehaviour(IIdentity identity)
        {
            _identity = identity;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var authorizeAttributes = request.GetType().GetCustomAttributes<AuthorizeAttribute>();

            if (authorizeAttributes.Any())
            {
                if (!_identity.IsAuthenticated)
                {
                    throw new UnauthorizedAccessException("Current User is not authenticated."); // TODO : hardcode
                }

                var authorizeAttributesWithPolicies = authorizeAttributes.Where(a => a.MenuName != null).ToList();

                foreach (var menuName in authorizeAttributesWithPolicies.Select(a => a.MenuName))
                {
                    // action
                    foreach (var actionName in authorizeAttributesWithPolicies.Select(a => a.ActionName))
                    {
                        var menuWithAction = $"{menuName}.{actionName}";
                        var haveMenuAccess = _identity.MenuAccess.Any(x => x.ToLower() == menuWithAction.Trim().ToLower());

                        if (!haveMenuAccess)
                        {

                            var errorMessage = $"{_identity.Email} does not have the following permission: {menuWithAction}";
                            throw new UnauthorizedAccessException(errorMessage);
                        }
                    }


                }
            }

            return await next();
        }
    }
}
