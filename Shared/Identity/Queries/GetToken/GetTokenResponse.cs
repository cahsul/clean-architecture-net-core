using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Identity.Queries.GetToken
{
    public class GetTokenResponse
    {
        public string JwtToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
