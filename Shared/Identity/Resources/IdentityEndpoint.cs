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
        }

    }
}
