using System;
using System.Collections.Generic;
using System.Text;
using Shared.X.Responses;

namespace Shared.User.Queries.GetUser
{
    public class GetUserResponse : BaseResponse<Guid>
    {
        public string Email { get; set; }
    }
}
