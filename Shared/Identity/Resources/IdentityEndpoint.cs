using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Identity.Resources
{
    public class IdentityEndpoint
    {
        public static class Identity
        {

            public const string Register = "/" + nameof(Identity) + "/" + nameof(Register);
            public const string Login = "/" + nameof(Identity) + "/" + nameof(Login);
            public const string RefreshToken = "/" + nameof(Identity) + "/" + nameof(RefreshToken);
            public const string GetToken = "/" + nameof(Identity) + "/" + nameof(GetToken);
            public const string GetIdentity = "/" + nameof(Identity) + "/" + nameof(GetIdentity);
        }

    }
}
