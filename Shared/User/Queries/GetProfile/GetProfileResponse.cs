using System;
using System.Collections.Generic;
using System.Text;
using Shared.X.Responses;

namespace Shared.User.Queries.GetProfile
{
    public class GetProfileResponse : BaseResponse<Guid>
    {
        public string Email { get; set; }
    }
}
