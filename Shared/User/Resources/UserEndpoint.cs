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
        }

    }
}
