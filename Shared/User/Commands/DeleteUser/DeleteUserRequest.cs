using System;
using System.Collections.Generic;
using System.Text;
using Shared.X.Requests;

namespace Shared.User.Commands.DeleteUser
{
    public class DeleteUserRequest : BaseRequest
    {
        public string Id { get; set; }
    }
}
