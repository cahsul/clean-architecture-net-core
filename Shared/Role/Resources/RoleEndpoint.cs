using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Role.Resources
{

    public class RoleEndpoint
    {
        public static class Role
        {
            public const string Create = "/" + nameof(Role) + "/" + nameof(Create);
            public const string Update = "/" + nameof(Role) + "/" + nameof(Update);
            public const string Delete = "/" + nameof(Role) + "/" + nameof(Delete);
            public const string GetRoles = "/" + nameof(Role) + "/" + nameof(GetRoles);
            public const string GetRole = "/" + nameof(Role) + "/" + nameof(GetRole);
        }

    }
}
