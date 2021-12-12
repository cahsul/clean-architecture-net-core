using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.User.Resources
{
    public class UserEndpoint
    {
        public static class User
        {
            public const string Profile = "/" + nameof(User) + "/" + nameof(Profile);
            public const string Create = "/" + nameof(User) + "/" + nameof(Create);
            public const string Update = "/" + nameof(User) + "/" + nameof(Update);
            public const string Delete = "/" + nameof(User) + "/" + nameof(Delete);
            public const string GetUsers = "/" + nameof(User) + "/" + nameof(GetUsers);
            public const string GetUser = "/" + nameof(User) + "/" + nameof(GetUser);

            public const string SetRole = "/" + nameof(User) + "/" + nameof(SetRole);
        }

    }
}
