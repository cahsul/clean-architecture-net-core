using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.User.Commands.AddRolesToUser
{
    public class AddRolesToUserRequest
    {
        public Guid UserId { get; set; }
        public List<Guid> Roles { get; set; }
    }
}
