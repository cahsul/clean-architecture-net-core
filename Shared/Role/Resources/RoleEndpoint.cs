using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Role.Resources
{

    public class RoleEndpoint
    {
        public static class Role
        {
            public const string Create = "/api/" + nameof(Role);
            public const string Update = "/api/" + nameof(Role);
            public const string Delete = "/api/" + nameof(Role) + "/" + nameof(Delete);
            public const string GetRoles = "/api/" + nameof(Role);
            public const string GetRole = "/api/" + nameof(Role);
        }

    }
}
