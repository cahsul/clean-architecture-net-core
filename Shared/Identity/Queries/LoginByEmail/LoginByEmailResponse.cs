using Shared._.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Identity.Queries.LoginByEmail
{
    public class LoginByEmailResponse
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTimeOffset ValidTo { get; set; }
    }
}
