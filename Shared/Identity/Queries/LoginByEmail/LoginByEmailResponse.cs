using System;

namespace Shared.Identity.Queries.LoginByEmail
{
    public class LoginByEmailResponse
    {
        public string JwtToken { get; set; }
        public string RefreshToken { get; set; }

        public string Email { get; set; }
    }
}
