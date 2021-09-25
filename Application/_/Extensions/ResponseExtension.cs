using Responses = Shared._.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Todos.Queries.GetTodos;

namespace Application._.Extensions
{

    public static class ResponseExtension
    {
        //public static Responses.Response<Responses.BaseResponse> Response(this Responses.BaseResponse response)
        //{
        //    return new Responses.Response<Responses.BaseResponse>
        //    {
        //        Data = response,
        //    };
        //}

        public static Responses.ResponseBuilder<T> Response<T>(this T response)
        {
            return new Responses.ResponseBuilder<T>
            {
                Data = response,
            };
        }


    }
}
