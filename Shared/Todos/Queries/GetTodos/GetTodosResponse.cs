using Shared._.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Todos.Queries.GetTodos
{
    //public class GetTodosResponse : BaseResponse<GetTodosResponse, Guid>
    public class GetTodosResponse : BaseResponse<Guid>
    {
        public string Title { get; set; }
    }

}
