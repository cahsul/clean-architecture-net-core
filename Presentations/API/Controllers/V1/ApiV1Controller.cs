using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Controllers.V1
{
    [Route("v1/[controller]")]
    //[ApiVersion(ApiVersionNumber.V_1_0)]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
    //[ProducesResponseType(StatusCodes.Status403Forbidden)]
    //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public abstract class ApiV1Controller : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator
        {
            get
            {
                return _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
            }
        }
    }
}
