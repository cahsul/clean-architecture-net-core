using MediatR;
using Shared._.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application._.Behaviours
{
    public class ResponseBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {

        public ResponseBehaviour()
        {
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var requestName = request.GetType();
            var response = await next();
            var erererer = response.GetType();

            return response;
        }
    }
}
