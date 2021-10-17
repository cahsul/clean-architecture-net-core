using System;

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
