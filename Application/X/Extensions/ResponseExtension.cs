using Responses = Shared.X.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Todos.Queries.GetTodos;
using Shared.Event.Resources;
using Shared.X.Resources;
using Shared.X.Responses;

namespace Application.X.Extensions
{

    public static class ResponseExtension
    {

        public static ResponseBuilder<T> ResponseCreate<T>(this T response, bool isPlural = false)
        {

            return new ResponseBuilder<T>
            {
                Message = isPlural ? ResponseLang.Response_CreatePlural : ResponseLang.Response_Create,
                Data = response,
            };
        }

        public static ResponseBuilder<T> Response<T>(this T response)
        {
            return new ResponseBuilder<T>
            {
                Data = response,
            };
        }


    }
}
