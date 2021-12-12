using System;
using System.Collections.Generic;
using System.Text;
using Shared.X.Responses;

namespace Shared.Role.Queries.GetRoles
{
    public class GetRolesResponse : BaseResponse<Guid>
    {
        public string RoleName { get; set; }
    }
}
