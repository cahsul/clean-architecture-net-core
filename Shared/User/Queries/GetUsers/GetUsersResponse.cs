using System;
using System.Collections.Generic;
using System.Text;
using Shared.X.Responses;

namespace Shared.User.Queries.GetUsers
{
    public class GetUsersResponse : BaseResponse<Guid>
    {
        public string Email { get; set; }
    }
}
