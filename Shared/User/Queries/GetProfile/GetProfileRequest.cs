using System;
using System.Collections.Generic;
using System.Text;
using Shared.X.Requests;

namespace Shared.User.Queries.GetProfile
{
    public class GetProfileRequest : BaseRequest
    {
        public string UserId { get; set; }
    }
}
