using MediatR;
using MediatR.Pipeline;
using Shared._.Responses;
using Shared.Todos.Commands.DeleteTodo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application._.Behaviours
{


    public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {

        public UnhandledExceptionBehaviour()
        {
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                //var requestName = typeof(TRequest).Name;
                //var formattedRequest = request.ToPrettyJson();
                //var username = _currentUser.IsAuthenticated ? _currentUser.Username : DefaultTextFor.SystemBackgroundJob;
                //var ipAddress = _currentUser.IpAddress;
                //var geolocation = _currentUser.Geolocation;

                //_logger.LogError(ex, "Unhandled Exception when executing {RequestName} by {Username} from {IpAddress} at {Latitude}||{Longitude}||{Accuracy}.\n{RequestName}\n{RequestObject}",
                //   requestName, username, ipAddress, geolocation?.Latitude, geolocation?.Longitude, geolocation?.Accuracy, requestName, formattedRequest);

                throw;
            }
        }
    }


    //public class UnhandledExceptionBehaviour<TRequest, TResponse> : RequestExceptionHandler<TRequest, TResponse>
    //{

    //    public UnhandledExceptionBehaviour()
    //    {
    //    }

    //    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    //    {
    //        //try
    //        //{
    //        //    return await next();
    //        //}
    //        //catch (Exception ex)
    //        //{
    //        //    var requestName = typeof(TRequest).Name;
    //        //    var formattedRequest = request.ToPrettyJson();
    //        //    var username = _currentUser.IsAuthenticated ? _currentUser.Username : DefaultTextFor.SystemBackgroundJob;
    //        //    var ipAddress = _currentUser.IpAddress;
    //        //    var geolocation = _currentUser.Geolocation;

    //        //    _logger.LogError(ex, "Unhandled Exception when executing {RequestName} by {Username} from {IpAddress} at {Latitude}||{Longitude}||{Accuracy}.\n{RequestName}\n{RequestObject}",
    //        //       requestName, username, ipAddress, geolocation?.Latitude, geolocation?.Longitude, geolocation?.Accuracy, requestName, formattedRequest);

    //        //    throw;
    //        //}
    //    }
    //}


    //public class UnhandledExceptionBehaviour<TRequest, TResponse> : RequestExceptionHandler<TRequest, TResponse, Exception>
    //where TRequest : BaseRequest<TResponse>
    //	where TResponse : BaseResponse, new()
    //{
    //	protected override void Handle(TRequest request, Exception exception, RequestExceptionHandlerState<TResponse> state)
    //	{
    //		var response = new TResponse
    //		{
    //			//Error = true,
    //			//ErrorMessage = exception.Message
    //		} as TResponse;

    //		state.SetHandled(response);
    //		//  state.SetHandled();
    //	}
    //}


    //public class UnhandledExceptionBehaviourzzzz<TRequest, TResponse> : RequestExceptionHandler<TRequest, TResponse, Exception>  //where TResponse : Exception
    //   {
    //       //private readonly ServiceFactory _serviceFactory;
    //       //public UnhandledExceptionBehaviour(ServiceFactory serviceFactory)
    //       //{
    //       //    _serviceFactory = serviceFactory;
    //       //}

    // //      public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next) 
    // //      {
    // //          return await next();

    // // //         try
    //	//	//{
    // // //             return await next();
    // // //         }
    //	//	//catch (Exception ex)
    //	//	//{
    // // //             var asdasda = new Customexp {
    // // //                 IsError = true,
    // // //                 ErrorsMessage = new List<string> { ex.Message },
    // // //             };

    //	//	//	return asdasda;
    //	//	//}
    //	//}

    //	protected override void Handle(TRequest request, Exception exception, RequestExceptionHandlerState<TResponse> state)
    //	{
    //		throw new NotImplementedException();
    //	}
    //}

    //   public class Customexp : Exception {

    //       //public Customexp()
    //       //{
    //       //}

    //       public bool IsError { get; set; } = false;
    //       public List<string> ErrorsMessage { get; set; } = new List<string>();

    //   }



    //public class UnhandledExceptionBehaviour<TRequest, TResponse, TException> : IRequestExceptionHandler<TRequest, TResponse, TException>
    //where TException : Exception
    //	//where TResponse : Response<DeleteTodoResponse>, new()
    //{

    //	//     public async Task Handle(TRequest request,
    //	//         TException exception,
    //	//         RequestExceptionHandlerState<TResponse> state,
    //	//         CancellationToken cancellationToken)
    //	//     {
    //	//return 1;

    //	////         var asdasd = new TResponse();

    //	////state.SetHandled(asdasd);
    //	////var gggg = state.Response;

    //	//     }
    //	public async Task Handle(TRequest request, TException exception, RequestExceptionHandlerState<TResponse> state, CancellationToken cancellationToken)
    //	{
    //		state.SetHandled(default);
    //	}
    //}
}
